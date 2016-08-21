#region License
//
// Servant
//
// Copyright 2016 Drew Noakes
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
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Servant
{
    /// <summary>
    /// Specifies how instances are reused between dependants.
    /// </summary>
    public enum Lifestyle
    {
        /// <summary>
        /// Only a single instance of the service will be created.
        /// </summary>
        Singleton,

        /// <summary>
        /// A new instance of the service will be created for each dependant.
        /// </summary>
        Transient
    }

    internal sealed class TypeEntry
    {
        public Type DeclaredType { get; }

        [CanBeNull] public TypeProvider Provider { get; set; }

        public TypeEntry(Type declaredType)
        {
            DeclaredType = declaredType;
        }
    }

    internal sealed class TypeProvider
    {
        public IReadOnlyList<TypeEntry> Dependencies { get; }

        private readonly Func<object[], Task<object>> _factory;
        private readonly Lifestyle _lifestyle;
        private readonly Type _declaredType;

        [CanBeNull] private object _singletonInstance;

        public TypeProvider(Func<object[], Task<object>> factory, Type declaredType, Lifestyle lifestyle, IReadOnlyList<TypeEntry> dependencies)
        {
            _factory = factory;
            _declaredType = declaredType;
            _lifestyle = lifestyle;
            Dependencies = dependencies;
        }

        public async Task<object> GetAsync()
        {
            // TODO make concurrency-safe here to avoid double-allocation of singleton

            if (_lifestyle == Lifestyle.Singleton && _singletonInstance != null)
                return _singletonInstance;

            // find arguments
            var argumentTasks = new List<Task<object>>();
            foreach (var dep in Dependencies)
            {
                if (dep.Provider == null)
                    throw new ServantException($"Type \"{dep.DeclaredType}\" is not registered.");
                argumentTasks.Add(dep.Provider.GetAsync());
            }

            await Task.WhenAll(argumentTasks);

            var instance = await _factory.Invoke(argumentTasks.Select(t => t.Result).ToArray());

            if (instance == null)
                throw new ServantException($"Instance for type \"{_declaredType}\" cannot be null.");

            if (!_declaredType.IsInstanceOfType(instance))
                throw new ServantException($"Instance produced for type \"{_declaredType}\" is not an instance of that type.");

            if (_lifestyle == Lifestyle.Singleton)
                _singletonInstance = instance;

            return instance;
        }
    }

    // TODO make disposable, disposing all singletons (what about transients?)

    /// <summary>
    /// Serves instances of specific types, resolving dependencies as required, and running any async initialisation.
    /// </summary>
    public sealed class Servant
    {
        private readonly ConcurrentDictionary<Type, TypeEntry> _entryByType = new ConcurrentDictionary<Type, TypeEntry>();

        private TypeEntry GetOrAddTypeEntry(Type declaredType) => _entryByType.GetOrAdd(declaredType, t => new TypeEntry(t));

        /// <summary>
        /// Adds the means of obtaining an instance of type <paramref name="declaredType"/>.
        /// </summary>
        /// <param name="lifestyle">Specifies how instances are reused between dependants.</param>
        /// <param name="declaredType">The <see cref="Type"/> via which instances must be requested.</param>
        /// <param name="factory">A function that returns an instance of <paramref name="declaredType"/> given a set of dependencies.</param>
        /// <param name="parameterTypes">The types of dependencies required by <paramref name="factory"/>.</param>
        public void Add(Lifestyle lifestyle, Type declaredType, Func<object[], Task<object>> factory, Type[] parameterTypes)
        {
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
                TypeEntry parameterTypeEntry;
                if (!_entryByType.TryGetValue(parameterType, out parameterTypeEntry))
                    continue;

                // Creates a cycle if one of parameterTypes depends upon declaredType
                if (DependsUpon(parameterTypeEntry, declaredType))
                    throw new ServantException($"Type \"{declaredType}\" cannot depend upon type \"{parameterType}\" as this would create circular dependencies.");
            }

            var typeEntry = GetOrAddTypeEntry(declaredType);

            if (typeEntry.Provider != null)
                throw new ServantException($"Type \"{declaredType}\" already registered.");

            typeEntry.Provider = new TypeProvider(factory, declaredType, lifestyle, parameterTypes.Select(GetOrAddTypeEntry).ToList());
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
        /// <remarks>If all singletons are already instantiated, calling this method has no effect.</remarks>
        /// <returns></returns>
        public Task CreateSingletonsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serves an instance of type <typeparamref name="T"/>, performing any requires async initialisation.
        /// </summary>
        /// <typeparam name="T">The type to be served.</typeparam>
        /// <returns>A task that completes when the instance is ready.</returns>
        public Task<T> ServeAsync<T>()
        {
            TypeEntry entry;
            if (!_entryByType.TryGetValue(typeof(T), out entry) || entry.Provider == null)
                throw new ServantException($"Type \"{typeof(T)}\" is not registered.");

            return TaskUtil.Upcast<T>(entry.Provider.GetAsync());
        }
    }

    /// <summary>
    /// An exception raised by Servant.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class ServantException : Exception
    {
        /// <inheritdoc />
        public ServantException() { }

        /// <inheritdoc />
        public ServantException(string message) : base(message) { }

        /// <inheritdoc />
        public ServantException(string message, Exception innerException) : base(message, innerException) { }
    }
}
