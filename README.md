# Servant

Async .NET dependency injection, while you await!

[![Build status](https://ci.appveyor.com/api/projects/status/ft0hgxx2tsn927gu?svg=true)](https://ci.appveyor.com/project/drewnoakes/servant)
[![Servant NuGet version](https://img.shields.io/nuget/v/Servant.svg)](https://www.nuget.org/packages/Servant/)

> **/səːv(ə)nt/**  
> _noun_  
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;One who waits on another

There are many DI frameworks out there already, so why another? Most frameworks predate C#'s `async`/`await` capabilities,
and are fundamentally incompatible with code that awaits during initialisation.
Such code must be _"async all the way down"_, and that's exactly what Servant is.

# Show me the code

```csharp
// Construct a new, empty, servant.
var servant = new Servant();

// Register type ServerProxy for implicit creation as a singleton.
servant.AddSingleton<ServerProxy>();

// Register type Config for explicit creation via the async Func<> as a transient.
servant.AddTransient<Config>(async (ServerProxy server) => await server.RequestConfig());

// Request Servant to serve up a Config instance.
// The singleton ServerProxy will be instantiated lazily and passed to the above Func<>.
var config = await servant.ServeAsync<Config>();
```

# Registering types

Each type registered with a `Servant` must be resolvable via one of the following means:
    
- An implicit constructor or factory call, as with `ServerProxy` above
- A `Func<>` returning a `T` or `Task<T>`, as with `ServerProxy` above
- A pre-constructed instance, such as `servant.AddSingleton(instance)`

Types can be `class` or `struct`, and may be `public`, `internal`, or `private`.

# Lifestyles

Types may be registered with one of two lifestyles:
    
- `Singleton` instances are created per servant. If multiple dependants for the type exist, they receive the same instance.
- `Transient` instances are created per request. Multiple dependants receive their own copies.

Note that the servant tracks singleton instances, and if they implement `IDisposable` will dispose them when you call `Servant.Dispose`.
Transient instances cannot be tracked by the servant, and their lifespans must be managed by their consumers.

# Rules for implicit creation

Types can be implicitly constructed via calls such as `AddSingleton<SomeType>()` so long as `SomeType` meets one of two criteria:

- Either it has a single public constructor, or
- It has a single static factory method (of any name) returning either `SomeType` or `Task<SomeType>`.

In general, constructor injection is simplest. However constructors cannot be `async`, whereas factory methods can be.

Here are two examples of valid types (member bodies omitted):

```csharp
public class ConstructorExample
{
    // Servant will find this constructor and call it to obtain an instance of the type.
    // There must be only a single public constructor to use constructor injection.
    public ConstructorExample(DependencyType1 dep1, DependencyType2 dep2)
    { }
}

public class FactoryExample
{
    // Servant will find this method and call it to obtain an instance of the type.
    // The method name doesn't matter. It must be public and static though.
    // The return type can be either Task<FactoryExample> or just FactoryExample.
    // There must be only one method on the type that meets these criteria.
    public static Task<FactoryExample> CreateAsync(DependencyType1 dep1, DependencyType2 dep2)
    { }

    private FactoryExample(/* ... */)
    { }
}


```

# Installation

Install the package from [NuGet](https://www.nuget.org/packages/Servant/):

> Install-Package Servant

Or clone the repo and build your own version.

# License

Copyright 2016-2017 Drew Noakes

> Licensed under the Apache License, Version 2.0 (the "License");
> you may not use this file except in compliance with the License.
> You may obtain a copy of the License at
>
>     http://www.apache.org/licenses/LICENSE-2.0
>
> Unless required by applicable law or agreed to in writing, software
> distributed under the License is distributed on an "AS IS" BASIS,
> WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
> See the License for the specific language governing permissions and
> limitations under the License.