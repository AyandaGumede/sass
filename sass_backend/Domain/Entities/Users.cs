using System.ComponentModel.DataAnnotations;

namespace sass.Domain.Entities
{
    public class User 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(3)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
