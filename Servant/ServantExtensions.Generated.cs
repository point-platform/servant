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
using System.Threading.Tasks;

namespace Servant
{
    // NOTE this file is generated

    public static partial class ServantExtensions
    {
        #region AddTransient

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has one dependency.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed one dependency.</param>
        public static void AddTransient<T1, TInstance>(this Servant servant, Func<T1, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0])),
                new[] {typeof(T1)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has one dependency.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed one dependency.</param>
        public static void AddTransient<T1, TInstance>(this Servant servant, Func<T1, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0])),
                new[] {typeof(T1)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has two dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed two dependencies.</param>
        public static void AddTransient<T1, T2, TInstance>(this Servant servant, Func<T1, T2, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1])),
                new[] {typeof(T1), typeof(T2)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has two dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed two dependencies.</param>
        public static void AddTransient<T1, T2, TInstance>(this Servant servant, Func<T1, T2, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1])),
                new[] {typeof(T1), typeof(T2)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has three dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed three dependencies.</param>
        public static void AddTransient<T1, T2, T3, TInstance>(this Servant servant, Func<T1, T2, T3, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2])),
                new[] {typeof(T1), typeof(T2), typeof(T3)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has three dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed three dependencies.</param>
        public static void AddTransient<T1, T2, T3, TInstance>(this Servant servant, Func<T1, T2, T3, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2])),
                new[] {typeof(T1), typeof(T2), typeof(T3)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has four dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed four dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, TInstance>(this Servant servant, Func<T1, T2, T3, T4, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has four dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed four dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, TInstance>(this Servant servant, Func<T1, T2, T3, T4, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has five dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed five dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has five dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed five dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has six dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed six dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has six dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed six dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has seven dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed seven dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has seven dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed seven dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has eight dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed eight dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has eight dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed eight dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has nine dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed nine dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has nine dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed nine dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has ten dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed ten dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has ten dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed ten dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has eleven dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed eleven dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has eleven dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed eleven dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has twelve dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed twelve dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has twelve dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed twelve dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has thirteen dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed thirteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has thirteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed thirteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has fourteen dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed fourteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has fourteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed fourteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has fifteen dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed fifteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has fifteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed fifteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has sixteen dependencies.
        /// </summary>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <typeparam name="T16">The sixteenth dependency type.</typeparam>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides an instance of <typeparamref name="TInstance"/> when passed sixteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TInstance> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14], (T16)args[15])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Transient"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has sixteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <typeparam name="T16">The sixteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides an instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed sixteen dependencies.</param>
        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Transient,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14], (T16)args[15])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16)});
        }


        #endregion

        #region AddSingleton

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has one dependency.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed one dependency.</param>
        public static void AddSingleton<T1, TInstance>(this Servant servant, Func<T1, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0])),
                new[] {typeof(T1)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has one dependency.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed one dependency.</param>
        public static void AddSingleton<T1, TInstance>(this Servant servant, Func<T1, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0])),
                new[] {typeof(T1)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has two dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed two dependencies.</param>
        public static void AddSingleton<T1, T2, TInstance>(this Servant servant, Func<T1, T2, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1])),
                new[] {typeof(T1), typeof(T2)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has two dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed two dependencies.</param>
        public static void AddSingleton<T1, T2, TInstance>(this Servant servant, Func<T1, T2, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1])),
                new[] {typeof(T1), typeof(T2)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has three dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed three dependencies.</param>
        public static void AddSingleton<T1, T2, T3, TInstance>(this Servant servant, Func<T1, T2, T3, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2])),
                new[] {typeof(T1), typeof(T2), typeof(T3)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has three dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed three dependencies.</param>
        public static void AddSingleton<T1, T2, T3, TInstance>(this Servant servant, Func<T1, T2, T3, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2])),
                new[] {typeof(T1), typeof(T2), typeof(T3)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has four dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed four dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, TInstance>(this Servant servant, Func<T1, T2, T3, T4, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has four dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed four dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, TInstance>(this Servant servant, Func<T1, T2, T3, T4, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has five dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed five dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has five dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed five dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has six dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed six dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has six dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed six dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has seven dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed seven dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has seven dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed seven dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has eight dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed eight dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has eight dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed eight dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has nine dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed nine dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has nine dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed nine dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has ten dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed ten dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has ten dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed ten dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has eleven dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed eleven dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has eleven dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed eleven dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has twelve dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed twelve dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has twelve dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed twelve dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has thirteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed thirteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has thirteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed thirteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has fourteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed fourteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has fourteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed fourteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has fifteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed fifteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has fifteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed fifteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via callback function <paramref name="func"/> which has sixteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <typeparam name="T16">The sixteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that provides the singleton instance of <typeparamref name="TInstance"/> when passed sixteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TInstance> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => Task.FromResult((object)func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14], (T16)args[15])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16)});
        }

        /// <summary>
        /// Registers type <typeparamref name="TInstance"/> with <see cref="Lifestyle.Singleton"/> lifestyle
        /// to be provided via asynchronous callback function <paramref name="func"/> which has sixteen dependencies.
        /// </summary>
        /// <typeparam name="TInstance">The type to register.</typeparam>
        /// <typeparam name="T1">The first dependency type.</typeparam>
        /// <typeparam name="T2">The second dependency type.</typeparam>
        /// <typeparam name="T3">The third dependency type.</typeparam>
        /// <typeparam name="T4">The fourth dependency type.</typeparam>
        /// <typeparam name="T5">The fifth dependency type.</typeparam>
        /// <typeparam name="T6">The sixth dependency type.</typeparam>
        /// <typeparam name="T7">The seventh dependency type.</typeparam>
        /// <typeparam name="T8">The eighth dependency type.</typeparam>
        /// <typeparam name="T9">The nineth dependency type.</typeparam>
        /// <typeparam name="T10">The tenth dependency type.</typeparam>
        /// <typeparam name="T11">The eleventh dependency type.</typeparam>
        /// <typeparam name="T12">The twelfth dependency type.</typeparam>
        /// <typeparam name="T13">The thirteenth dependency type.</typeparam>
        /// <typeparam name="T14">The fourteenth dependency type.</typeparam>
        /// <typeparam name="T15">The fifteenth dependency type.</typeparam>
        /// <typeparam name="T16">The sixteenth dependency type.</typeparam>
        /// <param name="servant">The <see cref="Servant"/> to register the type/function with.</param>
        /// <param name="func">A function that asynchronously provides the singleton instance of <typeparamref name="TInstance"/> via a <see cref="Task{TResult}"/> when passed sixteen dependencies.</param>
        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, Task<TInstance>> func)
        {
            servant.Add(
                Lifestyle.Singleton,
                typeof(TInstance),
                args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14], (T16)args[15])),
                new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16)});
        }


        #endregion
    }
}