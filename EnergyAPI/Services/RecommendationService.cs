using EnergyAPI.Models;
using EnergyAPI.Repositories.Interfaces;
using EnergyAPI.Services.Interfaces;

namespace EnergyAPI.Services {
    public class RecommendationService : IRecommendationService {
        private readonly IRecommendationRepository _recommendationRepository;

        // Construtor com injeção de dependências
        public RecommendationService(IRecommendationRepository recommendationRepository) {
            _recommendationRepository = recommendationRepository;
        }

        // Método para obter recomendação por ID
        public async Task<Recommendation?> GetRecommendationByIdAsync(int id) {
            return await _recommendationRepository.GetRecommendationByIdAsync(id);
        }

        // Método para obter todas as recomendações
        public async Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync() {
            return await _recommendationRepository.GetAllRecommendationsAsync();
        }

        // Método para adicionar uma nova recomendação
        public async Task AddRecommendationAsync(Recommendation recommendation) {
            await _recommendationRepository.AddRecommendationAsync(recommendation);
        }

        // Método para atualizar uma recomendação
        public async Task UpdateRecommendationAsync(Recommendation recommendation) {
            await _recommendationRepository.UpdateRecommendationAsync(recommendation);
        }

        // Método para deletar uma recomendação
        public async Task DeleteRecommendationAsync(int id) {
            await _recommendationRepository.DeleteRecommendationAsync(id);
        }
    }
}
