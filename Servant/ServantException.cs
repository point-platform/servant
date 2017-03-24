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
using System.Diagnostics.CodeAnalysis;

namespace Servant
{
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