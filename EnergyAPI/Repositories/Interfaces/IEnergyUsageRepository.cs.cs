namespace EnergyAPI.Repositories.Interfaces {
    public interface IEnergyUsageRepository {
        Task<EnergyUsage?> GetEnergyUsageByIdAsync(int id);
        Task<IEnumerable<EnergyUsage>> GetAllEnergyUsagesAsync();
        Task AddEnergyUsageAsync(EnergyUsage energyUsage);
        Task UpdateEnergyUsageAsync(EnergyUsage energyUsage);
        Task DeleteEnergyUsageAsync(int id);
    }
}
