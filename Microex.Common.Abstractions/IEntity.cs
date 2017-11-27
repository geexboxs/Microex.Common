using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microex.Common.Abstractions
{
    /// <summary>
    /// abstraction for database entity classes
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// create time
        /// </summary>
        DateTime CreateTime { get; set; }
        /// <summary>
        /// last update time, null if not modified after created
        /// </summary>
        DateTime? LastCreateTime { get; set; }
    }
}
