Optional
========
Optional<T> for C#.. for tracking if an objects value has ever been set. 
Works with Classes, Value Types and Nullable<T>.

[![Build status](https://ci.appveyor.com/api/projects/status/06b0gr6ixw4s4yn0?svg=true)](https://ci.appveyor.com/project/mgazza/optional)

Restful - Partial Updates
-------------------------
Optional allows a restful service to provide clients with a flexible contract where by they can submit the fields they require to be updated.

Scenario
--------

Client 1 has the contract
```
{Id, Name, AddressLine1}
```
Client 2 has the contract
```
{Id, Salary}
```

The Rest Service has the following contract
```csharp
public class Person {
  public int Id {get; set;}
  public Optional<string> Name {get; set;}
  public Optional<string> AddressLine1 {get; set;}
  public Optional<int?> Salary {get; set;}
}
```

Optional allows either client to supply any of the optional properties including setting the field to null where allowed.

Usage samples
-------------
Please checkout the branch and see Mgazza.Optional.Tests for example usages.

MVC quick-start sample
----------------------
in your global.ascx.cs add the following and you'll be ready to create the above scenario

```csharp
protected void Application_Start()
{
    var httpConfiguration = GlobalConfiguration.Configuration;
	var settings = httpConfiguration.Formatters.JsonFormatter.SerializerSettings;
	settings.Converters.Add(new OptionalJsonConverter());
	settings.NullValueHandling = NullValueHandling.Ignore;

	settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
	settings.NullValueHandling = NullValueHandling.Include;
	settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
	settings.DateParseHandling = DateParseHandling.DateTimeOffset;
	
	}
````