﻿#region License
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

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;

#pragma warning disable 1998

namespace Servant.Tests
{
    // TODO test failure cases
    // - value types (should this be allowed)
    // - primitive types
    // TODO test factories throwing
    // TODO get with timeout

    [ExcludeFromCodeCoverage]
    public class Test1 { }

	[ExcludeFromCodeCoverage]
    public class Test2
    {
        public Test1 Test1 { get; }
        public Test2(Test1 test1) { Test1 = test1; }
    }

    public class ServantTests
    {
        [Fact]
        public async Task AddTransient_AsyncFunc_NoDependencies()
        {
            var servant = new Servant();

            var test1 = new Test1();
            var callCount1 = 0;

            servant.AddTransient(async () =>
            {
                callCount1++;
                return test1;
            });

            Assert.Same(test1, await servant.ServeAsync<Test1>());
            Assert.Equal(1, callCount1);

            Assert.Same(test1, await servant.ServeAsync<Test1>());
            Assert.Equal(2, callCount1); // func was called again, as transient
        }

        [Fact]
        public async Task AddSingleton_AsyncFunc_NoDependencies()
        {
            var servant = new Servant();

            var test1 = new Test1();
            var callCount1 = 0;

            servant.AddSingleton(async () =>
            {
                callCount1++;
                return test1;
            });

            Assert.Same(test1, await servant.ServeAsync<Test1>());
            Assert.Equal(1, callCount1);

            Assert.Same(test1, await servant.ServeAsync<Test1>());
            Assert.Equal(1, callCount1);
        }

        [Fact]
        public async Task AddSingleton_AsyncFunc_SingleDependency()
        {
            var servant = new Servant();

            var test1 = new Test1();
            var callCount1 = 0;

            var test2 = new Test2(test1);
            var callCount2 = 0;

            servant.AddSingleton(async () =>
            {
                callCount1++;
                return test1;
            });

            servant.AddSingleton<Test1, Test2>(async dep =>
            {
                Assert.Same(test1, dep);
                Assert.Equal(1, callCount1);
                callCount2++;
                return test2;
            });

            Assert.Same(test1, await servant.ServeAsync<Test1>());
            Assert.Equal(1, callCount1);
            Assert.Equal(0, callCount2);

            Assert.Same(test1, await servant.ServeAsync<Test1>());
            Assert.Equal(1, callCount1);
            Assert.Equal(0, callCount2);

            Assert.Same(test2, await servant.ServeAsync<Test2>());
            Assert.Equal(1, callCount1);
            Assert.Equal(1, callCount2);

            Assert.Same(test2, await servant.ServeAsync<Test2>());
            Assert.Equal(1, callCount1);
            Assert.Equal(1, callCount2);
        }

        [Fact]
        public async Task AddSingleton_Instance()
        {
            var servant = new Servant();

            var test1 = new Test1();

            servant.AddSingleton(test1);

            Assert.Same(test1, await servant.ServeAsync<Test1>());
        }

        [Fact]
        public async Task AddSingleton_Instance_NoDependency()
        {
            var servant = new Servant();

            var test1 = new Test1();

            servant.AddSingleton(test1);

            Assert.Same(test1, await servant.ServeAsync<Test1>());
        }

        [Fact]
        public async Task AddSingleton_Ctor_NoDependency()
        {
            var servant = new Servant();

            servant.AddSingleton<Test1>();

            Assert.IsType<Test1>(await servant.ServeAsync<Test1>());
        }

        [Fact]
        public async Task AddSingleton_Ctor_SingleDependency()
        {
            var servant = new Servant();

            servant.AddSingleton<Test1>();
            servant.AddSingleton<Test2>();

            var test2 = await servant.ServeAsync<Test2>();
            Assert.IsType<Test2>(test2);
            Assert.IsType<Test1>(test2.Test1);
        }

        [Fact]
        public async Task Add_DuplicateDependencyTypesDisallowed()
        {
            var servant = new Servant();

            var exception = Assert.Throws<ServantException>(
                () => servant.AddSingleton<Test1, Test1, Test2>((a, b) => (Test2)null));

            Assert.Equal(
                $"Type \"{typeof(Test2)}\" has multiple dependencies upon type \"{typeof(Test1)}\", which is disallowed.",
                exception.Message);
        }

        [Fact]
        public async Task Add_DependsUponDeclaredType()
        {
            var servant = new Servant();

            var exception = Assert.Throws<ServantException>(
                () => servant.AddSingleton<Test1, Test1>(a => (Test1)null));

            Assert.Equal(
                $"Type \"{typeof(Test1)}\" depends upon its own type, which is disallowed.",
                exception.Message);
        }

        [Fact]
        public async Task Add_TypeAlreadyRegistered()
        {
            var servant = new Servant();

            servant.AddSingleton<Test1>();

            var exception = Assert.Throws<ServantException>(
                () => servant.AddSingleton<Test1>());

            Assert.Equal(
                $"Type \"{typeof(Test1)}\" already registered.",
                exception.Message);
        }

        #region Cycles

		[ExcludeFromCodeCoverage]
        private class Cycle1
        {
            public Cycle1(Cycle2 c) { }
        }

		[ExcludeFromCodeCoverage]
        private class Cycle2
        {
            public Cycle2(Cycle3 c) { }
        }

		[ExcludeFromCodeCoverage]
        private class Cycle3
        {
            public Cycle3(Cycle1 c) { }
        }

        [Fact]
        public async Task Add_CycleThrows()
        {
            var servant = new Servant();

            servant.AddSingleton((Cycle2 c) => new Cycle1(c));
            servant.AddSingleton((Cycle3 c) => new Cycle2(c));

            var exception = Assert.Throws<ServantException>(
                () => servant.AddSingleton((Cycle1 c) => new Cycle3(c)));

            Assert.Equal(
                $"Type \"{typeof(Cycle3)}\" cannot depend upon type \"{typeof(Cycle1)}\" as this would create circular dependencies.",
                exception.Message);
        }

        #endregion
    }
}
