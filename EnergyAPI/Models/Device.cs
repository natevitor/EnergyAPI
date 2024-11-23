using System.ComponentModel.DataAnnotations;

namespace EnergyAPI.Models {
    public class Device {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // Inicializado para evitar null

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; // Inicializado para evitar null

        [Required]
        public double PowerRating { get; set; }

        public string? Brand { get; set; } // Anulável, já que é opcional

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
