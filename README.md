# StarCitizenGalaxyWrapper
A C# wrapper around the Star Citizen Galaxy API\
https://sc-galaxy.com/

## Configure the service in DI
In order to use this service it requires some confguration of the .NET Core DI. A service collection extension is created for you to call in order to configure the services below:
```CSharp
var services = new ServiceCollection()
    .AddStarCitizenGalaxyApiLibrary()
    ...
    .BuildServiceCollection();
```
## Feel free to contribute via a pull request

# NuGet package
https://www.nuget.org/packages/StarCitizenGalaxyWrapper/