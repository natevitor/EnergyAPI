using EnergyAPI.Models;
using System.ComponentModel.DataAnnotations;

public class Recommendation {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty; // Inicializando com string vazia

    [Required]
    public int DeviceId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Device? Device { get; set; } // Tornando anulável
}
