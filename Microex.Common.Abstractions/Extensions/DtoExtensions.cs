using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microex.Common.Abstractions.Extensions
{
    public static class DtoExtensions
    {
        public static void SetStatus(this IResponse @this, int code,string message = "")
        {
            @this.Status = new ResponseStatus() {Code = code, Message = message};
        }
    }
}
