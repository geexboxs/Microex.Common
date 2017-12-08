using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microex.Common.Abstractions.Entity
{
    public class SoftDeletableEntity:EntityBase
    {
        public bool IsDeleted { get; set; }
    }
}
