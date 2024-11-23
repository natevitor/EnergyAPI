using EnergyAPI.Models;

namespace EnergyAPI.Services.IA {
    public interface IEnergyService {
        // Métodos para dispositivos
        Task<Device?> GetDeviceByIdAsync(int id);
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task AddDeviceAsync(Device device);
        Task UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(int id);

        // Métodos para consumo de energia
        Task<EnergyUsage?> GetEnergyUsageByIdAsync(int id);
        Task<IEnumerable<EnergyUsage>> GetAllEnergyUsagesAsync();
        Task AddEnergyUsageAsync(EnergyUsage energyUsage);
        Task UpdateEnergyUsageAsync(EnergyUsage energyUsage);
        Task DeleteEnergyUsageAsync(int id);

        // Métodos para recomendações
        Task<Recommendation?> GetRecommendationByIdAsync(int id);
        Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync();
        Task AddRecommendationAsync(Recommendation recommendation);
        Task UpdateRecommendationAsync(Recommendation recommendation);
        Task DeleteRecommendationAsync(int id);

        // Métodos para IA
        double PredictEnergyUsage(double previousUsage);  // Método de previsão
    }
}
