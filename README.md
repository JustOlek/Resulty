# Resulty
[![Nuget downloads](https://img.shields.io/nuget/v/resulty.svg)](https://www.nuget.org/packages/Resulty/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/alex-selehenenko/Resulty/blob/master/LICENSE)

Result type implementation for handling success and failure outcomes in a more expressive and type-safe manner. The library is designed to facilitate error handling and flow control in .Net applications.

### Creating Results
To create a result, you can use static factory methods provided by the Result class. Here are some examples:
```csharp
Result successResult = Result.Success();
Result<string> successResultWithValue = Result.Success("Hello, world!");

Result failureResult = Result.Failure(new Error("An error occurred"));
Result<int> failureResultWithValue = Result.Failure<int>(new Error("An error occurred"));
```
### Error Codes
The Error class in Resulty has a property called Code, which allows you to add additional identifiers to errors. This can be useful, for example, when associating HTTP status codes with errors. Some of the common HTTP status codes are implemented in the static factory methods of the Result class. Heare are some examples:
```csharp
Result notFoundResult = Result.NotFound();
Result<string> badRequestResult = Result.BadRequest("Invalid request data");
Result conflictResult = Result.Conflict();
```
### Chaining Results
There are extension methods that allow chaining results together and performing actions based on the success or failure of each result:
```csharp
Result<UserAccount> result = await GetUserAccountAsync()
    .Then(account => ChargeUserAccountAsync(account))
    .Then(account => SaveDataAsync(account));
```
Results in a chain can also be transformed using extension methods. These methods enable converting one type of result to another or performing custom transformations on the result value:
```csharp
Result<int> result = Result.Success<int>(200);

Result<string> transformedResult = result.ThenWithTransform(code => Result.Success<string>("Status code: " + code.ToString()));
```
### Mapping Results
Result can be mapped to any type, allowing you to transform the result based on its success or failure. Here are some examples:
```csharp
string message = SomeOperation()
    .Map(
        onSuccess: data => "Success: " + data.ToString(),
        onError: error => "Error occurred: " + error.Message
    );

```
In the above code, the `SomeOperation()` method returns a Result instance. We use the Map method to map the result to a string. The `onSuccess` function is provided to handle the successful case, where we construct a string by concatenating "Success: " with the result value converted to a string. The `onError` function handles the error case, where we construct a string by concatenating "Error occurred: " with the error message.
