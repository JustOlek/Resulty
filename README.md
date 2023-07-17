# Resulty
[![Nuget downloads](https://img.shields.io/nuget/v/resulty.svg)](https://www.nuget.org/packages/Resulty/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/alex-selehenenko/Resulty/blob/master/LICENSE)

Result object implementation for handling success and failure outcomes.

### Creating Results
`Result.cs` provides several static factory methods that can be used to create a new instance of `Result.cs`. Here are some examples:
```csharp
Result successResult = Result.Success();
Result<string> successResultWithValue = Result.Success("Hello, world!");

Result failureResult = Result.Failure(new Error("An error occurred"));
Result<int> failureResultWithValue = Result.Failure<int>(new Error("An error occurred"));
```
### Error Codes
It is possible to add additional identifiers to `Error.cs` using property `Code`. This can be useful, for example, when associating HTTP status codes with errors. Some of the common HTTP status codes are implemented in the static factory methods of the `Result.cs`:
```csharp
Result notFoundResult = Result.NotFound();
Result<string> badRequestResult = Result.BadRequest("Invalid request data");
Result conflictResult = Result.Conflict();
```
### Chaining Results
Operations can be chained together using `Then` extension method. If any operation in the chain fails, subsequent operations will not be executed, and a failed result will be returned. 
```csharp
Result<UserAccount> result = await GetUserAccountAsync()
    .Then(account => ChargeUserAccountAsync(account))
    .Then(account => SaveDataAsync(account));
```
`Result<T>` can also be transformed in a chain using extension method `ThenWithTransform`. It enables converting one type of `Result<T>` to another:
```csharp
Result<int> result = Result.Success<int>(200);

Result<string> transformedResult = result.ThenWithTransform(code => Result.Success<string>("Status code: " + code.ToString()));
```
### Mapping Results
`Result` can be mapped to any type, based on its success or failure:
```csharp
string message = SomeOperation()
    .Map(
        onSuccess: data => "Success: " + data.ToString(),
        onError: error => "Error occurred: " + error.Message
    );

```
In the above code, the `SomeOperation()` method returns a Result instance. We use the Map method to map the result to a string. The `onSuccess` function is provided to handle the successful case, where we construct a string by concatenating "Success: " with the result value converted to a string. The `onError` function handles the error case, where we construct a string by concatenating "Error occurred: " with the error message.
