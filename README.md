# **Microex.Common** #

### Common extensions &amp; tools to speed up coding ###

## **Packages** ##

### Microex.Common ###

*this package defined some prefered `SerializeSettings` and **extension method** of Json.Net*

`DefaultSerializeSettings` for common use case:
```
ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
TypeNameHandling = TypeNameHandling.Auto,
TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
DateFormatString = "yyyy-MM-dd HH:mm:ss",
Converters = new List<JsonConverter>()
{
    new StringEnumConverter()
}
```

`IgnoreErrorSerializeSettings` for complicate serialization(eg: **serialize exception** for logging):
```
ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
Error = (sender, args) =>
{
    args.ErrorContext.Handled = true;
},
TypeNameHandling = TypeNameHandling.Auto,
TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
DateFormatString = "yyyy-MM-dd HH:mm:ss",
Converters = new List<JsonConverter>()
{
    new StringEnumConverter()
}
```

#### Usage: ####
override `JsonConvert.DefaultSerializeSettings` or use `obj.ToJson()` & `json.ToObject<T>()`

### Microex.Common.Mvc ###
*this package defined some prefered **extension method** for **aspnet core project** especially for **angular4***

perform
`iApplicationBuilder.AddAngularRoute()`
to integrate angular index.html at one line of code.

perform
`iMvcBuilder.AddPrefferedJsonSettings()`
to override mvc default json serialize settings.

### Microex.Common.Abstractions ###

Todo
