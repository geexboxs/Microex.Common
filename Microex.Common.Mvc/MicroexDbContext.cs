using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microex.Common.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Microex.Common.Mvc
{
    public class MicroexDbContext:DbContext,ISeedableDbContext
    {
        public virtual void Seed()
        {
            
        }
    }
}
