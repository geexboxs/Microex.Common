using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microex.Common.Abstractions.Entity
{
    /// <summary>
    /// abstraction for softdeletable entity classes
    /// </summary>
    public interface ISoftDeletable:IEntity
    {
        bool IsDeleted { get; set; }
    }
}
