using System.ComponentModel.DataAnnotations;

namespace Microex.Common.Abstractions.Dto
{
    public interface IResponse
    {
        [Required]
        ResponseStatus Status { get; set; }
    }
}
