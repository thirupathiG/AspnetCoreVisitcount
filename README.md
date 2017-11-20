# Cloud Foundry ASP.NET Core - Visit Count sample application using redis cache

A simple ASP.NET Core web application using redis cache for the [ASP.NET Core buildpack][].

## Push to Cloud Foundry

```
git clone https://github.com/priyakantpatel/aspnet-core-visitcount.git
cf push -b https://github.com/cloudfoundry-community/dotnet-core-buildpack.git
cf create-service p-redis shared-vm my-core-redis
cf bind-service aspnet-core-visitcount my-core-redis
cf restart aspnet-core-visitcount

Browse application url (my pcfdev url look like http://aspnet-core-visitcount.local.pcfdev.io/)
```

## Run the app locally

1. Install ASP.NET Core by following the [Getting Started][] instructions
+ Clone this app
+ cd into the app directory and then `src\aspnet-core-visitcount`
+ Run `dotnet restore`
+ Run `dotnet run`
+ Access the running app in a browser at [http://localhost:5000](http://localhost:5000)

## Note
Application is reading 1st redis config entry for a convianance purpose from Environment variable "VCAP_SERVICES", please check CachManager.cs.

Thanks to [Patrick Crocker][] for all his help.

[Getting Started]: http://docs.asp.net/en/latest/getting-started/index.html
[ASP.NET Core buildpack]: https://github.com/cloudfoundry-community/asp.net5-buildpack
[Patrick Crocker]: https://github.com/patrickcrocker