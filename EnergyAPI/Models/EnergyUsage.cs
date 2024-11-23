using EnergyAPI.Models;
using System.ComponentModel.DataAnnotations;

public class EnergyUsage {
    [Key]
    public int Id { get; set; }

    [Required]
    public int DeviceId { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    [Required]
    public double EnergyConsumed { get; set; }

    public Device? Device { get; set; } // Tornando anulável
}
