using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyAPI.Data;
using EnergyAPI.Models;
using EnergyAPI.Repositories.Interfaces;

namespace EnergyAPI.Repositories {
    public class DeviceRepository : IDeviceRepository {
        private readonly AppDbContext _context;

        // Construtor com verificação de nulidade
        public DeviceRepository(AppDbContext context) {
            ArgumentNullException.ThrowIfNull(context, nameof(context)); // Verificação de nulidade
            _context = context;
        }

        // Método para buscar um dispositivo por ID
        public async Task<Device?> GetDeviceByIdAsync(int id) // Tipo anulável
        {
            return await _context.Devices.FindAsync(id); // Retorna null se não encontrar
        }

        // Método para buscar todos os dispositivos
        public async Task<IEnumerable<Device>> GetAllDevicesAsync() {
            return await _context.Devices.ToListAsync();
        }

        // Método para adicionar um novo dispositivo
        public async Task AddDeviceAsync(Device device) {
            ArgumentNullException.ThrowIfNull(device, nameof(device)); // Verificação de nulidade
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        // Método para atualizar um dispositivo existente
        public async Task UpdateDeviceAsync(Device device) {
            ArgumentNullException.ThrowIfNull(device, nameof(device)); // Verificação de nulidade
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        // Método para excluir um dispositivo
        public async Task DeleteDeviceAsync(int id) {
            var device = await GetDeviceByIdAsync(id);
            if (device != null) {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}
