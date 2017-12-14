using System;

namespace Microex.Common.Abstractions.Entity
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
        DateTime? LastUpdateTime { get; set; }
    }
}
