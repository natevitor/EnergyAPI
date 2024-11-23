using Microsoft.AspNetCore.Mvc;
using EnergyAPI.Models;
using EnergyAPI.Services.IA;

namespace EnergyAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase {
        private readonly IEnergyService _energyService;

        public DeviceController(IEnergyService energyService) {
            _energyService = energyService;
        }

        // GET: api/device/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDeviceByIdAsync(int id) {
            var device = await _energyService.GetDeviceByIdAsync(id);
            if (device == null) {
                return NotFound(); // Retorna 404 caso o dispositivo não seja encontrado
            }

            return Ok(device); // Retorna 200 com o dispositivo se encontrado
        }

        // GET: api/device
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetAllDevicesAsync() {
            var devices = await _energyService.GetAllDevicesAsync();
            return Ok(devices); // Retorna todos os dispositivos
        }

        // POST: api/device
        [HttpPost]
        public async Task<ActionResult<Device>> AddDeviceAsync([FromBody] Device device) {
            if (device == null) {
                return BadRequest("Dispositivo não pode ser nulo.");
            }

            await _energyService.AddDeviceAsync(device);

            // Retorna CreatedAtActionResult (201) com o local do recurso
            return CreatedAtAction(nameof(GetDeviceByIdAsync), new { id = device.Id }, device);
        }

        // PUT: api/device/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDeviceAsync(int id, [FromBody] Device device) {
            if (device == null || id != device.Id) {
                return BadRequest("Dispositivo inválido.");
            }

            await _energyService.UpdateDeviceAsync(device);
            // Retorna NoContent (204) quando a atualização é bem-sucedida
            return NoContent();
        }

        // DELETE: api/device/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceAsync(int id) {
            var device = await _energyService.GetDeviceByIdAsync(id);
            if (device == null) {
                return NotFound(); // Retorna 404 se o dispositivo não for encontrado
            }

            await _energyService.DeleteDeviceAsync(id);
            // Retorna NoContent (204) quando a exclusão é bem-sucedida
            return NoContent();
        }
    }
}
