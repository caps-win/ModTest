
# ModTest


This implementation allows you to use different types of destinations for logging messages: `Console`, `File` and `Database`


Log levels available : `Message`, `Warning` and `Error`
_____

### Configuration

The configuration depends on the types you want to implement:


For `File` :

You have to specify the following keys on you `App.Config`

```xml
 <add key="LogDestination" value="File" /> <!-- use to active File logging feature -->
 <add key="FileDirectory" value="PUT_YOUR_PATH_HERE" />
```

For `Database` :

You have to specify the following keys on you `App.Config`

```xml
 <add key="LogDestination" value="Database" /> <!-- use to active Database logging feature -->
 <add key="ConnectionString" value="PUT_YOUR_SERVER_HERE" />
 <add key="LogTable" value="Logging" /> <!-- table name hosted on you sql server -->
```

  
NOTE: You can combine those types of destinations at the same time, just separating each one by a comma:
```xml
 <add key="LogDestination" value="Console,File,Database" /> 

```

----

### Example

* Logging information type:

```cs
 JobLogger.Message("I am message notification");

```

* Logging warning type:

```cs

 JobLogger.Warning("I am warning notification");
```

* Logging error type:

```cs

 JobLogger.Error("I am error notification");

```
