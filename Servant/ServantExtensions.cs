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
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Servant
{
    /// <summary>
    /// Extension methods for working with instances of <see cref="Servant"/>.
    /// </summary>
    public static partial class ServantExtensions
    {
        /// <summary>
        /// Adds an existing instance of type <typeparamref name="TInstance"/> as a singleton.
        /// </summary>
        /// <remarks>There is no <see cref="Lifestyle.Transient"/> equivalent of this method.</remarks>
        /// <typeparam name="TInstance">The declared type of the instance being added.</typeparam>
        /// <param name="servant">The instance of <see cref="Servant"/> to add the singleton instance to.</param>
        /// <param name="instance">The singleton instance to add for type <typeparamref name="TInstance"/>.</param>
        public static void AddSingleton<TInstance>(this Servant servant, TInstance instance)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)instance),
                Type.EmptyTypes);
        }

        public static void AddSingleton<TInstance>(this Servant servant)
        {
            Type[] parameterTypes;
            Func<object[], Task<object>> func;
            GetConstructor(typeof(TInstance), out parameterTypes, out func);

            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                func,
                parameterTypes);
        }

        private static void GetConstructor(Type type, out Type[] parameterTypes, out Func<object[], Task<object>> func)
        {
            var constructors = type.GetConstructors();

            if (constructors.Length != 1)
                throw new Exception($"Type {type} must have a single constructor.");

            // TODO validate all types involved are reference types (?) or support boxing value types
            // TODO validate nothing fancy about the parameters
            // TODO support default parameter values?

            parameterTypes = constructors[0].GetParameters().Select(p => p.ParameterType).ToArray();

            var method = new DynamicMethod(
                $"{type.Name}ConstructorFunc",
                returnType: typeof(Task<object>),
                parameterTypes: new[] { typeof(object[]) },
                restrictedSkipVisibility: true);

            var ilg = method.GetILGenerator();

            for (var i = 0; i < parameterTypes.Length; i++)
            {
                var parameterType = parameterTypes[i];

                // load array element
                ilg.Emit(OpCodes.Ldarg_0);
                ilg.Emit(OpCodes.Ldc_I4, i);
                ilg.Emit(OpCodes.Ldelem_Ref);

                ilg.Emit(OpCodes.Castclass, parameterType);
            }

            ilg.Emit(OpCodes.Newobj, constructors[0]);

            ilg.Emit(OpCodes.Castclass, typeof(object));

            ilg.Emit(OpCodes.Call, typeof(Task).GetMethod(nameof(Task.FromResult)).MakeGenericMethod(typeof(object)));

            ilg.Emit(OpCodes.Ret);

            func = (Func<object[], Task<object>>)method.CreateDelegate(typeof(Func<object[], Task<object>>));
        }
    }
}