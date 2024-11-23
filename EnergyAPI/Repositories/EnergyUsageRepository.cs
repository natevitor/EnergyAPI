using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyAPI.Data;
using EnergyAPI.Models;
using EnergyAPI.Repositories.Interfaces;

namespace EnergyAPI.Repositories {
    public class EnergyUsageRepository : IEnergyUsageRepository {
        private readonly AppDbContext _context;

        // Construtor com verificação de nulidade
        public EnergyUsageRepository(AppDbContext context) {
            ArgumentNullException.ThrowIfNull(context, nameof(context)); // Verificação de nulidade
            _context = context;
        }

        // Método para buscar o consumo de energia por ID
        public async Task<EnergyUsage?> GetEnergyUsageByIdAsync(int id) // Tipo anulável
        {
            return await _context.EnergyUsages.FindAsync(id); // Retorna null se não encontrar
        }

        // Método para buscar todos os consumos de energia
        public async Task<IEnumerable<EnergyUsage>> GetAllEnergyUsagesAsync() {
            return await _context.EnergyUsages.ToListAsync();
        }

        // Método para adicionar um novo consumo de energia
        public async Task AddEnergyUsageAsync(EnergyUsage energyUsage) {
            ArgumentNullException.ThrowIfNull(energyUsage, nameof(energyUsage)); // Verificação de nulidade
            await _context.EnergyUsages.AddAsync(energyUsage);
            await _context.SaveChangesAsync();
        }

        // Método para atualizar um consumo de energia existente
        public async Task UpdateEnergyUsageAsync(EnergyUsage energyUsage) {
            ArgumentNullException.ThrowIfNull(energyUsage, nameof(energyUsage)); // Verificação de nulidade
            _context.EnergyUsages.Update(energyUsage);
            await _context.SaveChangesAsync();
        }

        // Método para excluir um consumo de energia
        public async Task DeleteEnergyUsageAsync(int id) {
            var energyUsage = await GetEnergyUsageByIdAsync(id);
            if (energyUsage != null) {
                _context.EnergyUsages.Remove(energyUsage);
                await _context.SaveChangesAsync();
            }
        }
    }
}
