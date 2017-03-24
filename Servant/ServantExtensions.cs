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
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Servant
{
    /// <summary>
    /// Extension methods for working with instances of <see cref="Servant"/>.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static partial class ServantExtensions
    {
        #region AddTransient

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> for constructor or factory dependency injection
        /// with <see cref="Lifestyle.Transient"/> lifestyle.
        /// </summary>
        /// <remarks>
        /// <typeparamref name="TInstance"/> must either have:
        /// <list type="bullet">
        ///   <item>a single public constructor, or</item>
        ///   <item>a single static method (of any name) returning either <c>TInstance</c> or <c>Task&lt;TInstance&gt;</c>.</item>
        /// </list>
        /// Any any parameter types of the constructor/factory method must registered with <paramref name="servant"/>
        /// before calling <see cref="Servant.ServeAsync{T}"/>.
        /// </remarks>
        /// <typeparam name="TInstance">The type to register with the servant.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type with.</param>
        public static void AddTransient<[MeansImplicitUse] TInstance>(this Servant servant)
        {
            GetConstructionFunc(
                typeof(TInstance),
                out Type[] parameterTypes,
                out Func<object[], Task<object>> func);

            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                func,
                parameterTypes);
        }

        /// <summary>
        /// Registers type <typeparamref name="TDeclared"/> to be resolved by sub-type
        /// <typeparamref name="TInstance"/> which is instantiated via constructor or factory dependency injection
        /// with <see cref="Lifestyle.Transient"/> lifestyle.
        /// </summary>
        /// <remarks>
        /// <typeparamref name="TInstance"/> must either have:
        /// <list type="bullet">
        ///   <item>a single public constructor, or</item>
        ///   <item>a single static method (of any name) returning either <c>TInstance</c> or <c>Task&lt;TInstance&gt;</c>.</item>
        /// </list>
        /// Any any parameter types of the constructor/factory method must registered with <paramref name="servant"/>
        /// before calling <see cref="Servant.ServeAsync{T}"/>.
        /// </remarks>
        /// <typeparam name="TDeclared">The type to register and later search by.</typeparam>
        /// <typeparam name="TInstance">The type to instantiate when providing an instance of <typeparamref name="TDeclared"/>.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type with.</param>
        public static void AddTransient<TDeclared, [MeansImplicitUse] TInstance>(this Servant servant) where TInstance : TDeclared
        {
            GetConstructionFunc(typeof(TInstance), out Type[] parameterTypes, out Func<object[], Task<object>> func);

            servant.Add(
                Lifestyle.Transient,
                typeof(TDeclared),
                func,
                parameterTypes);
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has no dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/>.</param>
        [ExcludeFromCodeCoverage]
        public static void AddTransient<TInstance>(this Servant servant, Func<TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func()),
                Type.EmptyTypes);
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has no dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/>.</param>
        [ExcludeFromCodeCoverage]
        public static void AddTransient<TInstance>(this Servant servant, Func<Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func()),
                Type.EmptyTypes);
        }

        #endregion

        #region AddSingleton

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> as a <see cref="Lifestyle.Singleton"/> to be created via constructor or factory dependency injection.
        /// </summary>
        /// <remarks>
        /// Instantiation occurs when first required, or when <see cref="Servant.CreateSingletonsAsync"/> is invoked.
        /// <para />
        /// <typeparamref name="TInstance"/> must either have:
        /// <list type="bullet">
        ///   <item>a single public constructor, or</item>
        ///   <item>a single static method (of any name) returning either <c>TInstance</c> or <c>Task&lt;TInstance&gt;</c>.</item>
        /// </list>
        /// Any any parameter types of the constructor/factory method must registered with <paramref name="servant"/>
        /// before calling <see cref="Servant.ServeAsync{T}"/> or <see cref="Servant.CreateSingletonsAsync"/>.
        /// </remarks>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type with.</param>
        public static void AddSingleton<[MeansImplicitUse] TInstance>(this Servant servant)
        {
            GetConstructionFunc(typeof(TInstance), out Type[] parameterTypes, out Func<object[], Task<object>> func);

            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                func,
                parameterTypes);
        }

        /// <summary>
        /// Registers type <typeparamref name="TDeclared"/> to be resolved by sub-type
        /// <typeparamref name="TInstance"/> which is instantiated via constructor or factory dependency injection
        /// with <see cref="Lifestyle.Singleton"/> lifestyle.
        /// </summary>
        /// <remarks>
        /// <typeparamref name="TInstance"/> must either have:
        /// <list type="bullet">
        ///   <item>a single public constructor, or</item>
        ///   <item>a single static method (of any name) returning either <c>TInstance</c> or <c>Task&lt;TInstance&gt;</c>.</item>
        /// </list>
        /// Any any parameter types of the constructor/factory method must registered with <paramref name="servant"/>
        /// before calling <see cref="Servant.ServeAsync{T}"/> or <see cref="Servant.CreateSingletonsAsync"/>.
        /// </remarks>
        /// <typeparam name="TDeclared">The type to register and later search by.</typeparam>
        /// <typeparam name="TInstance">The type to instantiate when providing an instance of <typeparamref name="TDeclared"/>.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type with.</param>
        public static void AddSingleton<TDeclared, [MeansImplicitUse] TInstance>(this Servant servant) where TInstance : TDeclared
        {
            GetConstructionFunc(typeof(TInstance), out Type[] parameterTypes, out Func<object[], Task<object>> func);

            servant.Add(
                Lifestyle.Singleton,
                typeof(TDeclared),
                func,
                parameterTypes);
        }

        /// <summary>
        /// Adds an existing instance of type <typeparamref name="TInstance"/> as a <see cref="Lifestyle.Singleton"/>.
        /// </summary>
        /// <remarks>There is no <see cref="Lifestyle.Transient"/> equivalent of this method.</remarks>
        /// <typeparam name="TInstance">The declared type of the instance being added.</typeparam>
        /// <param name="servant">The instance of <see cref="Servant"/> to add the singleton instance to.</param>
        /// <param name="instance">The singleton instance to add for type <typeparamref name="TInstance"/>.</param>
        public static void AddSingleton<TInstance>(this Servant servant, [NotNull] TInstance instance)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)instance),
                Type.EmptyTypes);
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has no dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/>.</param>
        [ExcludeFromCodeCoverage]
        public static void AddSingleton<TInstance>(this Servant servant, Func<TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func()),
                Type.EmptyTypes);
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has no dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/>.</param>
        [ExcludeFromCodeCoverage]
        public static void AddSingleton<TInstance>(this Servant servant, Func<Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func()),
                Type.EmptyTypes);
        }

        #endregion

        private static void GetConstructionFunc(Type type, out Type[] parameterTypes, out Func<object[], Task<object>> func)
        {
            var constructors = type.GetConstructors();

            var factoryMethods =
                (from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                where method.ReturnType == type || method.ReturnType == typeof(Task<>).MakeGenericType(type)
                select method).ToList();

            var canUseConstructor = constructors.Length == 1;
            var canUseFactory = factoryMethods.Count == 1;

            if (!canUseConstructor && !canUseFactory)
                throw new ServantException($"Type \"{type}\" must have a single public constructor, or a single public static factory method (returning \"{type}\" or \"Task<{type}>\" to use implicit construction. Either ensure a single public constructor or factory method exists, or register the type with a Func<> instead.");

            // TODO validate all types involved are reference types (?) or support boxing value types
            // TODO validate nothing fancy about the parameters
            // TODO support default parameter values?

            var dynamicMethod = new DynamicMethod(
                $"{type.Name}ConstructionFunc",
                returnType: typeof(Task<object>),
                parameterTypes: new[] { typeof(object[]) },
                restrictedSkipVisibility: true);

            var ilg = dynamicMethod.GetILGenerator();

            var parameterInfos = canUseConstructor
                ? constructors[0].GetParameters()
                : factoryMethods[0].GetParameters();

            parameterTypes = parameterInfos.Select(p => p.ParameterType).ToArray();

            // Read parameter values from the array argument, and cast them to the required types
            for (var i = 0; i < parameterTypes.Length; i++)
            {
                var parameterType = parameterTypes[i];

                // load array element
                ilg.Emit(OpCodes.Ldarg_0);
                ilg.Emit(OpCodes.Ldc_I4, i);
                ilg.Emit(OpCodes.Ldelem_Ref);

                ilg.Emit(OpCodes.Castclass, parameterType);
            }

            if (canUseConstructor)
            {
                // Call the constructor
                ilg.Emit(OpCodes.Newobj, constructors[0]);

                // Downcast to object
                ilg.Emit(OpCodes.Castclass, typeof(object));

                // Store in a Task<object>
                ilg.Emit(OpCodes.Call, typeof(Task).GetMethod(nameof(Task.FromResult)).MakeGenericMethod(typeof(object)));
            }
            else
            {
                // Call the factory method
                ilg.Emit(OpCodes.Call, factoryMethods[0]);

                var hasTask = factoryMethods[0].ReturnType == typeof(Task<>).MakeGenericType(type);

                if (!hasTask)
                {
                    // Downcast to object
                    ilg.Emit(OpCodes.Castclass, typeof(object));

                    // Store in a Task<object>
                    ilg.Emit(OpCodes.Call, typeof(Task).GetMethod(nameof(Task.FromResult)).MakeGenericMethod(typeof(object)));
                }
                else
                {
                    // Downcast to Task<object>
                    ilg.Emit(OpCodes.Call, typeof(TaskUtil).GetMethod(nameof(TaskUtil.Downcast)).MakeGenericMethod(type));
                }
            }

            ilg.Emit(OpCodes.Ret);

            func = (Func<object[], Task<object>>)dynamicMethod.CreateDelegate(typeof(Func<object[], Task<object>>));
        }
    }
}