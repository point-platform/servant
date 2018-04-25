#region License
//
// Servant
//
// Copyright 2016-2018 Drew Noakes
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
}
