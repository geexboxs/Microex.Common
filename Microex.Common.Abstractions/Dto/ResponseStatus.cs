using System.ComponentModel.DataAnnotations;

namespace Microex.Common.Abstractions.Dto
{
    public class ResponseStatus
    {
        [Required]
        public int Code { get; set; }
        public object Data { get; set; }
    }
}
