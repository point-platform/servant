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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
#if NETSTANDARD1_3
using System.Reflection;
#endif

namespace Servant
{
    internal sealed class TypeProvider
    {
        public Lifestyle Lifestyle { get; }
        public IReadOnlyList<TypeEntry> Dependencies { get; }

        private readonly object _singletonLock = new object();
        private readonly Servant _servant;
        private readonly Func<object[], Task<object>> _factory;
        private readonly Type _declaredType;

        [CanBeNull] private Task<object> _singletonCreationTask;

        public TypeProvider(Servant servant, Func<object[], Task<object>> factory, Type declaredType, Lifestyle lifestyle, IReadOnlyList<TypeEntry> dependencies)
        {
            _servant = servant;
            _factory = factory;
            _declaredType = declaredType;
            Lifestyle = lifestyle;
            Dependencies = dependencies;
        }

        public async Task<object> GetAsync()
        {
            async Task<object> CreateAsync()
            {
                // find arguments
                var argumentTasks = new List<Task<object>>();
                foreach (var dep in Dependencies)
                {
                    if (dep.Provider == null)
                    {
                        // No provider exists for this dependency.
                        var message = $"Type \"{_declaredType}\" depends upon unregistered type \"{dep.DeclaredType}\".";

                        // See whether we have a super-type of the requested type.
                        var superTypes = _servant.GetRegisteredTypes().Where(type => type.IsAssignableFrom(dep.DeclaredType)).ToList();
                        if (superTypes.Any())
                            message += $" Did you mean to reference registered super type {string.Join(" or ", superTypes.Select(st => $"\"{st}\""))}?";

                        throw new ServantException(message);
                    }
                    argumentTasks.Add(dep.Provider.GetAsync());
                }

                await Task.WhenAll(argumentTasks);

                var instance = await _factory.Invoke(argumentTasks.Select(t => t.Result).ToArray());

                if (instance == null)
                    throw new ServantException($"Instance for type \"{_declaredType}\" cannot be null.");

                if (!_declaredType.IsInstanceOfType(instance))
                    throw new ServantException($"Instance produced for type \"{_declaredType}\" is not an instance of that type.");

                return instance;
            }

            if (Lifestyle == Lifestyle.Transient)
                return await CreateAsync();

            // Singleton

            if (_singletonCreationTask == null)
            {
                var created = false;
                lock (_singletonLock)
                {
                    if (_singletonCreationTask == null)
                    {
                        _singletonCreationTask = CreateAsync();
                        created = true;
                    }
                }

                var singleton = await _singletonCreationTask;

                if (created && singleton is IDisposable disposable)
                    _servant.PushDisposableSingleton(disposable);

                return singleton;
            }

            return await _singletonCreationTask;
        }
    }
}