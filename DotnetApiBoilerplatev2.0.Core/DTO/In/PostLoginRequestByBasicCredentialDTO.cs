using System.ComponentModel.DataAnnotations;

namespace DotnetApiBoilerplatev2._0.Core.DTO.In
{
    public class PostLoginRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
