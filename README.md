# Middelware for secure services on ArcGIS Server

This middelware will fetch an AGS access token and attach it to the incoming request.

Access tokens are cached for their lifetime and reused. Remember to include following NuGet packages.

* [Microsoft.Extensions.Caching.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Abstractions)
* [Microsoft.Extensions.Caching.Memory](https://www.nuget.org/packages/Microsoft.Extensions.Caching.Memory)


Orginallly developed for proxying OAuth2 to AGS token using [Microsoft.AspNetCore.Proxy](https://www.nuget.org/packages/Microsoft.AspNetCore.Proxy/0.1.0-rc2-final).