#region License
//
// Servant
//
// Copyright 2016-2017 Drew Noakes
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
// More information about this project is available at:
//
//    https://github.com/drewnoakes/servant
//
#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Servant
{
    /// <summary>
    /// Serves instances of specific types, resolving dependencies as required, and running any async initialisation.
    /// </summary>
    /// <remarks>
    /// Disposing this class will dispose any contained singleton instances that implement <see cref="IDisposable"/>.
    /// Transient instances are not tracked by this class and must be disposed by their consumers.
    /// </remarks>
    public sealed class Servant : IDisposable
    {
        private readonly ConcurrentDictionary<Type, TypeEntry> _entryByType = new ConcurrentDictionary<Type, TypeEntry>();
        private readonly ConcurrentStack<IDisposable> _disposableSingletons = new ConcurrentStack<IDisposable>();

        private int _disposed;

        private TypeEntry GetOrAddTypeEntry(Type declaredType) => _entryByType.GetOrAdd(declaredType, t => new TypeEntry(t));

        /// <summary>
        /// Adds the means of obtaining an instance of type <paramref name="declaredType"/>.
        /// </summary>
        /// <param name="lifestyle">Specifies how instances are reused between dependants.</param>
        /// <param name="declaredType">The <see cref="Type"/> via which instances must be requested.</param>
        /// <param name="factory">A function that returns an instance of <paramref name="declaredType"/> given a set of dependencies.</param>
        /// <param name="parameterTypes">The types of dependencies required by <paramref name="factory"/>.</param>
        public void Add(Lifestyle lifestyle, [NotNull] Type declaredType, [NotNull] Func<object[], Task<object>> factory, [NotNull, ItemNotNull] Type[] parameterTypes)
        {
            if (_disposed != 0)
                throw new ObjectDisposedException(nameof(Servant));

            if (!Enum.IsDefined(typeof(Lifestyle), lifestyle))
                throw new ArgumentOutOfRangeException(nameof(lifestyle), $"Value should be defined in the {nameof(Lifestyle)} enum.");

            // Validate the type doesn't depend upon itself
            if (parameterTypes.Contains(declaredType))
                throw new ServantException($"Type \"{declaredType}\" depends upon its own type, which is disallowed.");

            // Validate no duplicate parameter types
            var dupes = parameterTypes.GroupBy(t => t).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
            if (dupes.Count != 0)
                throw new ServantException($"Type \"{declaredType}\" has multiple dependencies upon type{(dupes.Count == 1 ? "" : "s")} {string.Join(", ", dupes.Select(t => $"\"{t}\""))}, which is disallowed.");

            // Validate we won't end up creating a cycle
            foreach (var parameterType in parameterTypes)
            {
                if (!_entryByType.TryGetValue(parameterType, out TypeEntry parameterTypeEntry))
                    continue;

                // Creates a cycle if one of parameterTypes depends upon declaredType
                if (DependsUpon(parameterTypeEntry, declaredType))
                    throw new ServantException($"Type \"{declaredType}\" cannot depend upon type \"{parameterType}\" as this would create circular dependencies.");
            }

            var typeEntry = GetOrAddTypeEntry(declaredType);

            if (typeEntry.Provider != null)
                throw new ServantException($"Type \"{declaredType}\" already registered.");

            typeEntry.Provider = new TypeProvider(this, factory, declaredType, lifestyle, parameterTypes.Select(GetOrAddTypeEntry).ToList());
        }

        private static bool DependsUpon(TypeEntry dependant, Type dependent)
        {
            if (dependant.Provider == null)
                return false;

            foreach (var dependency in dependant.Provider.Dependencies)
            {
                if (dependency.DeclaredType == dependent)
                    return true;

                if (DependsUpon(dependency, dependent))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Eagerly initialises all types registered as having <see cref="Lifestyle.Singleton"/> lifestyle.
        /// </summary>
        /// <remarks>
        /// Calling this method is optional. If not used, singletons will be initialised lazily, when first requested.
        /// <para />
        /// If all singletons are already instantiated, calling this method has no effect.
        /// </remarks>
        /// <returns>A task that completes when singleton initialisation has finished.</returns>
        public Task CreateSingletonsAsync()
        {
            if (_disposed != 0)
                throw new ObjectDisposedException(nameof(Servant));

            return Task.WhenAll(
                from typeEntry in _entryByType.Values
                let provider = typeEntry.Provider
                where provider?.Lifestyle == Lifestyle.Singleton
                select provider.GetAsync());
        }

        /// <summary>
        /// Serves an instance of type <typeparamref name="T"/>, performing any requires async initialisation.
        /// </summary>
        /// <typeparam name="T">The type to be served.</typeparam>
        /// <returns>A task that completes when the instance is ready.</returns>
        public Task<T> ServeAsync<T>()
        {
            if (_disposed != 0)
                throw new ObjectDisposedException(nameof(Servant));

            if (!_entryByType.TryGetValue(typeof(T), out TypeEntry entry) || entry.Provider == null)
                throw new ServantException($"Type \"{typeof(T)}\" is not registered.");

            return TaskUtil.Upcast<T>(entry.Provider.GetAsync());
        }

        /// <summary>
        /// Gets a value indicating whether the type <typeparamref name="T"/> has been registered with this servant.
        /// </summary>
        /// <remarks>
        /// Just because a type is registered, does not mean it can be served. It may depend upon other
        /// types which have not been registered.
        /// <para />
        /// If a type is known only as a dependency of a type passed to one of the <c>Add</c> methods,
        /// then this method returns <c>false</c>.
        /// </remarks>
        /// <typeparam name="T">The type to test for.</typeparam>
        /// <returns><c>true</c> if the type has been registered, otherwise <c>false</c>.</returns>
        public bool IsTypeRegistered<T>() => IsTypeRegistered(typeof(T));

        /// <summary>
        /// Gets a value indicating whether the type <paramref name="type"/> has been registered with this servant.
        /// </summary>
        /// <remarks>
        /// Just because a type is registered, does not mean it can be served. It may depend upon other
        /// types which have not been registered.
        /// <para />
        /// If a type is known only as a dependency of a type passed to one of the <c>Add</c> methods,
        /// then this method returns <c>false</c>.
        /// </remarks>
        /// <param name="type">The type to test for.</param>
        /// <returns><c>true</c> if the type has been registered, otherwise <c>false</c>.</returns>
        public bool IsTypeRegistered(Type type) => _entryByType.TryGetValue(type, out TypeEntry entry) && entry.Provider != null;

        /// <summary>
        /// Gets all types registered with this servant.
        /// </summary>
        /// <returns>An enumeration of registered types.</returns>
        public IEnumerable<Type> GetRegisteredTypes()
        {
            return from entry in _entryByType.Values
                   where entry.Provider != null
                   select entry.DeclaredType;
        }

        internal void PushDisposableSingleton(IDisposable disposableSingletonInstance)
        {
            // We push disposable instances onto a stack and dispose them in reverse order
            _disposableSingletons.Push(disposableSingletonInstance);
        }

        /// <summary>
        /// Produces a description of the directed graph of dependencies within this servant, in DOT syntax.
        /// </summary>
        /// <remarks>
        /// DOT syntax is straightforward and easily graphed using online software.
        /// <list type="bullet">
        /// <item>https://en.wikipedia.org/wiki/DOT_(graph_description_language)</item>
        /// <item>http://www.webgraphviz.com/</item>
        /// </list>
        /// </remarks>
        /// <exception cref="ServantException">One or more types do not have a provider.</exception>
        /// <returns>The directed dependency graph described in the DOT syntax.</returns>
        public string ToDotGraphString()
        {
            if (_disposed != 0)
                throw new ObjectDisposedException(nameof(Servant));

            var dot = new StringBuilder();

            dot.AppendLine("digraph servant {");

            foreach (var entry in _entryByType.Values)
            {
                if (entry.Provider == null)
                    throw new ServantException($"Type {entry.DeclaredType} does not have a provider.");

                dot.AppendLine($"    \"{entry.DeclaredType}\" -> {{ {string.Join(" ", entry.Provider.Dependencies.Select(d => $"\"{d.DeclaredType}\""))} }};");
            }

            dot.Append("}");

            return dot.ToString();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
                return;

            // TODO catch exceptions and throw an aggregate?
            while (_disposableSingletons.TryPop(out IDisposable disposable))
                disposable.Dispose();
        }
    }
}
