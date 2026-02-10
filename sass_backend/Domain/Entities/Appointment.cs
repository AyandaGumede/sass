using System.ComponentModel.DataAnnotations;

namespace sass.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        public int ServcideId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } 

        [Required]
        [MaxLength(1000)]
        public string Notes { get; set; }
    }

    public enum AppointmentStatus
    {
        Pending = 0,
        Confirmed = 1,
        Canceled = 2,
    }
}
