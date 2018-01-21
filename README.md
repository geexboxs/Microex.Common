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

#### Angular Spa Integration
perform
`iApplicationBuilder.AddAngularRoute()`
to integrate angular `index.html` at one line of code for something like this
```
app.Run(async (context) =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync(Path.Combine(wwwrootPath, angularIndexName));
});
```

---

#### Preffered Json Serialize Settings(damed JavaScript datetime, I want something like `2017-01-01 00:00:00`)

perform
`iMvcBuilder.AddPrefferedJsonSettings()`
to override mvc default json serialize settings.

---

add support for json-like params of http get request(when should we have a body in http get?)

backend is like this
```
[HttpGet("{startTime}/{endTime}")]
public List<FooDto> Get(DateTime startTime, DateTime endTime, [TypeConverter(typeof(JObjectConverter))] JObject json)
{
    var tags = json.ToObject<Dictionary<string, string>>();
    return _fooService.GetFoos(startTime, endTime, tags);
}
```
then request: `http://www.wtf.com/foos/2017-01-01/2019-01-01?tags=%7B%22what%22%3A%22the%20fuck%22%7D`

### Microex.Common.Abstractions ###

Todo

## **Documentation** ##
* Microex.Common
  * Microex.Common
    * Microex.Common.Extensions
      * [Microex.Common.Extensions.Encryption](https://github.com/microexs/Microex.Document/wiki/Microex.Common.Extensions.Encryption)
  * Microex.Common.Mvc
  * Microex.Common.Abstractions
