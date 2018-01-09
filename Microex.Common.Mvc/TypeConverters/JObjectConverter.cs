using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microex.Common.Extensions;
using Newtonsoft.Json.Linq;

namespace Microex.Common.Mvc.TypeConverters
{
    public class JObjectConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            if (value is string s)
            {
                try
                {
                    JObject dictionary = s.ToObject<JObject>();
                    return dictionary;
                }
                catch (Exception e)
                {
                    return null;
                }

            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
