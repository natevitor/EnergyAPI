namespace EnergyAPI.Repositories.Interfaces {
    public interface IRecommendationRepository {
        Task<Recommendation?> GetRecommendationByIdAsync(int id);
        Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync();
        Task AddRecommendationAsync(Recommendation recommendation);
        Task UpdateRecommendationAsync(Recommendation recommendation);
        Task DeleteRecommendationAsync(int id);
    }
}
