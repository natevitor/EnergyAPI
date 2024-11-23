using EnergyAPI.Models;

namespace EnergyAPI.Repositories.Interfaces  // Alterado para corresponder à estrutura da pasta
{
    public interface IDeviceRepository {
        Task<Device?> GetDeviceByIdAsync(int id);
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task AddDeviceAsync(Device device);
        Task UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(int id);
    }
}
