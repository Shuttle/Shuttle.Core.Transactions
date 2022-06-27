# Shuttle.Core.Transactions

```
PM> Install-Package Shuttle.Core.Transactions
```

This package makes use of the .Net `TransactionScope` class to provide ambient transaction handling.  If you are using .Net Core and you experience an error enlisting a transaction then try to upgrade the `System.Data.SqlClient` package.  If you are using the `DefaultTransactionScopeFactory` then you can also set the `enabled` attribute to `false` but then all transaction handling should be coded in the handlers (not recommended).

## Configuration

The relevant components may be configured using `IServiceColletion`.

In order to make use of transaction scopes:

```c#
services.AddTransactionScope(options => 
{
	options.WithIsolationLevel(isolationLevel)
	options.WithTimeout(timeout)
});
```

To register the `NullTransactionScoopeFactory`:

```c#
services.DisableTransactionScope();
```

The `appsettings.json` structure is as follows:

```json
{
	"Shuttle": {
		"TransactionScope": {
			"Enabled": true,
			"IsolationLevel": "isolation-level"
			"Timeout": "00:00:30"
		} 
	}
}
```

# ITransactionScope

An implementation of the `ITransactionScope` interface is used to wrap a `TransactionScope`.

The `DefaultTransactionScope` makes use of the standard .NET `TransactionScope` functionality.  There is also a `NullTransactionScope` that implements the null pattern so it implements the interface but does not do anything.

## Properties

### Name

``` c#
Guid Id { get; }
```

Returns the Id of the transaction scope.

## Methods

### Complete

``` c#
void Complete();
```

Marks the transaction scope as complete.

# ITransactionScopeFactory

An implementation of the `ITransactionScopeFactory` interface provides instances of an `ITransactionScope` implementation.

The `TransactionScopeFactory` provides a `DefaultTransactionScope` instance.

## Create

``` c#
ITransactionScope Create(IsolationLevel isolationLevel, TimeSpan timeout);
```

Creates the relevant instance using the given parameters.
