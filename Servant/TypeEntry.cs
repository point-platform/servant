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
using JetBrains.Annotations;

namespace Servant
{
    internal sealed class TypeEntry
    {
        public Type DeclaredType { get; }

        [CanBeNull] public TypeProvider Provider { get; set; }

        public TypeEntry(Type declaredType) => DeclaredType = declaredType;

        public override string ToString()
        {
            return Provider != null
                ? $"{DeclaredType} ({Provider.Dependencies.Count} {(Provider.Dependencies.Count == 1 ? "dependency" : "dependencies")})"
                : $"{DeclaredType} (no provider)";
        }
    }
}