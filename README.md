# Servant

Async .NET dependency injection, while you await!

> **/səːv(ə)nt/**  
> _noun_  
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;One who waits on another

There are many DI frameworks out there already, so why another? Most frameworks predate C#'s `async`/`await` capabilities,
and are fundamentally incompatible with code that awaits during initialisation.
Such code must be _"async all the way down"_, and that's exactly what Servant is.

```csharp
var servant = new Servant();

servant.AddSingleton<ServerProxy>();
servant.AddSingleton<Config>(async (ServerProxy server) => await server.RequestConfig());

var config = await servant.ServeAsync<Config>();
```

Each type added to a `Servant` must be resolved in a single operation:
    
- A constructor call, as with `ServerProxy` above
- A `Func<>` returning a `T` or `Task<T>`, as with `ServerProxy` above
- An instance directly, such as `servant.AddSingleton(instance)`

Types may have one of two lifestyles:
    
- `Singleton` instances are created only once
- `Transient` instances are created per request

## Installation

NuGet makes using the library easy:

> Install-Package Servant

## License