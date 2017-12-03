using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microex.Common.Abstractions
{
    public interface IResponse
    {
        ResponseStatus Status { get; set; }
    }
}
