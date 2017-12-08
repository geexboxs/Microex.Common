using System;

namespace Microex.Common.Abstractions.Entity
{
    /// <summary>
    /// abstraction for database entity classes
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// create time, auto generated, should not set
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// last update time, null if not modified after created, auto generated, should not set
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
    }
}
