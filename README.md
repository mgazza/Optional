Optional
========
Optional<T> for C#.. for tracking if an objects value has ever been set. 
Works with Classes, Value Types and Nullable<T>.

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
