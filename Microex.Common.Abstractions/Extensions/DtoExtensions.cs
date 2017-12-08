using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microex.Common.Abstractions.Dto;

namespace Microex.Common.Abstractions.Extensions
{
    public static class DtoExtensions
    {
        public static void SetStatus(this IResponse @this, int code,object status = null)
        {
            @this.Status = new ResponseStatus() {Code = code, Status = status };
        }
    }
}
