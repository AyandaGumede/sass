using System.ComponentModel.DataAnnotations;

namespace sass.Application.DTOs.Authentication
{
    public class LoginDTO
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }

    }
}
