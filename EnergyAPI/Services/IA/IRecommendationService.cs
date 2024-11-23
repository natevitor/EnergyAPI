using EnergyAPI.Models;

namespace EnergyAPI.Services.Interfaces {
    public interface IRecommendationService {
        // Métodos para obter recomendação por ID
        Task<Recommendation?> GetRecommendationByIdAsync(int id);

        // Métodos para obter todas as recomendações
        Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync();

        // Métodos para adicionar uma recomendação
        Task AddRecommendationAsync(Recommendation recommendation);

        // Métodos para atualizar uma recomendação
        Task UpdateRecommendationAsync(Recommendation recommendation);

        // Métodos para deletar uma recomendação
        Task DeleteRecommendationAsync(int id);
    }
}
