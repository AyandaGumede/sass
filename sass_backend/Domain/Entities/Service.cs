using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace sass.Domain.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(5, 480)]
        public int DurationMinutes { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}
