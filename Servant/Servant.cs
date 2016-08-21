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
    // Async .NET dependency injection, while you await!

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
        public Type DeclaredType { get; }
        public Lifestyle Lifestyle { get; }
        public IReadOnlyList<TypeEntry> Dependencies { get; }

        private readonly Func<object[], Task<object>> _factory;

        [CanBeNull] private object _singletonInstance;

        public TypeProvider(Func<object[], Task<object>> factory, Type declaredType, Lifestyle lifestyle, IReadOnlyList<TypeEntry> dependencies)
        {
            _factory = factory;
            DeclaredType = declaredType;
            Lifestyle = lifestyle;
            Dependencies = dependencies;
        }

        public async Task<object> GetAsync()
        {
            // TODO make concurrency-safe here to avoid double-allocation of singleton

            if (Lifestyle == Lifestyle.Singleton && _singletonInstance != null)
                return _singletonInstance;

            // TODO throw if re-entrant, using thread local? might not work in case of multi-threaded task scheduling

            // find arguments
            var argumentTasks = Dependencies.Select(dep => dep.Provider.GetAsync()).ToList();

            await Task.WhenAll(argumentTasks);

            var instance = await _factory.Invoke(argumentTasks.Select(t => t.Result).ToArray());

            // TODO validate not null
            // TODO validate is declared type

            if (Lifestyle == Lifestyle.Singleton)
                _singletonInstance = instance;

            return instance;
        }
    }

    // TODO make disposable, disposing all singletons (what about transients?)

    public class Servant
    {
        private readonly ConcurrentDictionary<Type, TypeEntry> _nodeByType = new ConcurrentDictionary<Type, TypeEntry>();

        private bool _validationRequired;

        private TypeEntry GetOrAddTypeNode(Type declaredType) => _nodeByType.GetOrAdd(declaredType, t => new TypeEntry(t));

        public void Add(Lifestyle lifestyle, Type declaredType, Func<object[], Task<object>> factory, Type[] parameterTypes)
        {
            // TODO validate no duplicate parameter types
            // TODO validate declared type not present in parameter list
            // TODO if creation fails somehow, might need to delete the node (or do work in lambda passed to GetOrAdd so throw prohibits add
            var typeNode = GetOrAddTypeNode(declaredType);

            if (typeNode.Provider != null)
                throw new InvalidOperationException($"Type {declaredType} already registered.");

            typeNode.Provider = new TypeProvider(factory, declaredType, lifestyle, parameterTypes.Select(GetOrAddTypeNode).ToList());
        }

        private void Validate()
        {
            if (!_validationRequired)
                return;

            // TODO validate dependency graph does not contain cycles

            _validationRequired = false;
        }

        public Task CreateSingletonsAsync()
        {
            Validate();

            throw new NotImplementedException();
        }

        public Task<T> ServeAsync<T>()
        {
            Validate();

            TypeEntry entry;
            if (!_nodeByType.TryGetValue(typeof(T), out entry))
                throw new InvalidOperationException($"Type {typeof(T)} not supported.");

            return TaskUtil.Upcast<T>(entry.Provider.GetAsync());
        }
    }
}
