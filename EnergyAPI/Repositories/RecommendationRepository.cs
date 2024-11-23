using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyAPI.Data;
using EnergyAPI.Models;
using EnergyAPI.Repositories.Interfaces;

namespace EnergyAPI.Repositories {
    public class RecommendationRepository : IRecommendationRepository {
        private readonly AppDbContext _context;

        // Construtor com verificação de nulidade
        public RecommendationRepository(AppDbContext context) {
            ArgumentNullException.ThrowIfNull(context, nameof(context)); // Verificação de nulidade
            _context = context;
        }

        // Método para buscar uma recomendação por ID
        public async Task<Recommendation?> GetRecommendationByIdAsync(int id) // Tipo anulável
        {
            return await _context.Recommendations.FindAsync(id); // Retorna null se não encontrar
        }

        // Método para buscar todas as recomendações
        public async Task<IEnumerable<Recommendation>> GetAllRecommendationsAsync() {
            return await _context.Recommendations.ToListAsync();
        }

        // Método para adicionar uma nova recomendação
        public async Task AddRecommendationAsync(Recommendation recommendation) {
            ArgumentNullException.ThrowIfNull(recommendation, nameof(recommendation)); // Verificação de nulidade
            await _context.Recommendations.AddAsync(recommendation);
            await _context.SaveChangesAsync();
        }

        // Método para atualizar uma recomendação existente
        public async Task UpdateRecommendationAsync(Recommendation recommendation) {
            ArgumentNullException.ThrowIfNull(recommendation, nameof(recommendation)); // Verificação de nulidade
            _context.Recommendations.Update(recommendation);
            await _context.SaveChangesAsync();
        }

        // Método para excluir uma recomendação
        public async Task DeleteRecommendationAsync(int id) {
            var recommendation = await GetRecommendationByIdAsync(id);
            if (recommendation != null) {
                _context.Recommendations.Remove(recommendation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
