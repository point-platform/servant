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
using System.Threading.Tasks;

namespace Servant
{
    // NOTE this file is generated

    public static partial class ServantExtensions
    {
		#region AddTransient

        public static void AddTransient<TInstance>(this Servant servant, Func<Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func()),
				Type.EmptyTypes);
        }

        public static void AddTransient<T1, TInstance>(this Servant servant, Func<T1, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0])),
				new[] {typeof(T1)});
        }

        public static void AddTransient<T1, T2, TInstance>(this Servant servant, Func<T1, T2, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1])),
				new[] {typeof(T1), typeof(T2)});
        }

        public static void AddTransient<T1, T2, T3, TInstance>(this Servant servant, Func<T1, T2, T3, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2])),
				new[] {typeof(T1), typeof(T2), typeof(T3)});
        }

        public static void AddTransient<T1, T2, T3, T4, TInstance>(this Servant servant, Func<T1, T2, T3, T4, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
        }

        public static void AddTransient<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Transient,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
        }

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

        public static void AddSingleton<TInstance>(this Servant servant, Func<Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func()),
				Type.EmptyTypes);
        }

        public static void AddSingleton<T1, TInstance>(this Servant servant, Func<T1, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0])),
				new[] {typeof(T1)});
        }

        public static void AddSingleton<T1, T2, TInstance>(this Servant servant, Func<T1, T2, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1])),
				new[] {typeof(T1), typeof(T2)});
        }

        public static void AddSingleton<T1, T2, T3, TInstance>(this Servant servant, Func<T1, T2, T3, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2])),
				new[] {typeof(T1), typeof(T2), typeof(T3)});
        }

        public static void AddSingleton<T1, T2, T3, T4, TInstance>(this Servant servant, Func<T1, T2, T3, T4, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14)});
        }

        public static void AddSingleton<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TInstance>(this Servant servant, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Task<TInstance>> func)
        {
            servant.Add(
			    Lifestyle.Singleton,
				typeof(TInstance),
				args => TaskUtil.Downcast(func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7], (T9)args[8], (T10)args[9], (T11)args[10], (T12)args[11], (T13)args[12], (T14)args[13], (T15)args[14])),
				new[] {typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15)});
        }

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