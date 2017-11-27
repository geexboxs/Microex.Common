using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microex.Common
{
    public static class Json
    {
        public static JsonSerializerSettings _DefaultSerializeSettings { get; set; } = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //Error = (sender, args) =>
            //{
            //    args.ErrorContext.Handled = true;
            //},
            TypeNameHandling = TypeNameHandling.Auto,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter()
            }
            //ContractResolver = new AllPropertiesResolver()
        };

        public static JsonSerializerSettings _IgnoreErrorSerializeSettings { get; set; } = new JsonSerializerSettings()
        {
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
            //ContractResolver = new AllPropertiesResolver()
        };

        public static string ToJson(this object @this, bool ignoreError = true)
        {
            if (ignoreError)
            {
                return JsonConvert.SerializeObject(@this, _IgnoreErrorSerializeSettings);
            }
            else
            {
                return JsonConvert.SerializeObject(@this, _DefaultSerializeSettings);
            }
        }

        public static T ToObject<T>(this string @this, bool ignoreError = true)
        {
            if (ignoreError)
            {
                return JsonConvert.DeserializeObject<T>(@this, _IgnoreErrorSerializeSettings);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(@this, _DefaultSerializeSettings);
            }
        }
    }
}
