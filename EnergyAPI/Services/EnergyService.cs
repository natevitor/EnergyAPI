using EnergyAPI.Models;
using EnergyAPI.Repositories.Interfaces;
using EnergyAPI.Services.IA;
using EnergyAPI.Services.Interfaces; // Corrigir o namespace para corresponder ao da interface

namespace EnergyAPI.Services {
    public class EnergyService : IEnergyService {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IEnergyUsageRepository _energyUsageRepository;
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IPredictionService _predictionService;

        // Construtor com injeção de dependências
        public EnergyService(IDeviceRepository deviceRepository, IEnergyUsageRepository energyUsageRepository, IRecommendationRepository recommendationRepository, IPredictionService predictionService) {
            _deviceRepository = deviceRepository;
            _energyUsageRepository = energyUsageRepository;
            _recommendationRepository = recommendationRepository;
            _predictionService = predictionService;
        }

        // Métodos para dispositivos
        public async Task<Device?> GetDeviceByIdAsync(int id) {
            return await _deviceRepository.GetDeviceByIdAsync(id);
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync() {
            return await _deviceRepository.GetAllDevicesAsync();
        }

        public async Task AddDeviceAsync(Device device) {
            await _deviceRepository.AddDeviceAsync(device);
        }

        public async Task UpdateDeviceAsync(Device device) {
            await _deviceRepository.UpdateDeviceAsync(device);
        }

        public async Task DeleteDeviceAsync(int id) {
            await _deviceRepository.DeleteDeviceAsync(id);
        }

        // Métodos para consumo de energia
        public async Task<EnergyUsage?> GetEnergyUsageByIdAsync(int id) {
            return await _energyUsageRepository.GetEnergyUsageByIdAsync(id);
        }

        public async Task<IEnumerable<EnergyUsage>> GetAllEnergyUsagesAsync() {
            return await _energyUsageRepository.GetAllEnergyUsagesAsync();
        }

        public async Task AddEnergyUsageAsync(EnergyUsage energyUsage) {
            await _energyUsageRepository.AddEnergyUsageAsync(energyUsage);
        }

        public async Task UpdateEnergyUsageAsync(EnergyUsage energyUsage) {
            await _energyUsageRepository.UpdateEnergyUsageAsync(energyUsage);
        }

        public async Task DeleteEnergyUsageAsync(int id) {
            await _energyUsageRepository.DeleteEnergyUsageAsync(id);
        }

        // Métodos para recomendações
        public async Task<Recommendation?> GetRecommendationByIdAsync(int id) {
            return await _recommendationRepository.GetRecommendationByIdAsync(id);
        }

        public async Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync() {
            return await _recommendationRepository.GetAllRecommendationsAsync();
        }

        public async Task AddRecommendationAsync(Recommendation recommendation) {
            await _recommendationRepository.AddRecommendationAsync(recommendation);
        }

        public async Task UpdateRecommendationAsync(Recommendation recommendation) {
            await _recommendationRepository.UpdateRecommendationAsync(recommendation);
        }

        public async Task DeleteRecommendationAsync(int id) {
            await _recommendationRepository.DeleteRecommendationAsync(id);
        }

        // Método de previsão de consumo de energia
        public double PredictEnergyUsage(double previousUsage) {
            return _predictionService.PredictEnergyUsage(previousUsage); // Usando o PredictionService para previsões
        }
    }
}
