using Microsoft.AspNetCore.Mvc;
using EnergyAPI.Models;
using EnergyAPI.Services.IA;

namespace EnergyAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyUsageController : ControllerBase {
        private readonly IEnergyService _energyService;

        public EnergyUsageController(IEnergyService energyService) {
            _energyService = energyService;
        }

        // GET: api/energyusage/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyUsage>> GetEnergyUsageByIdAsync(int id) {
            var energyUsage = await _energyService.GetEnergyUsageByIdAsync(id);
            if (energyUsage == null) {
                return NotFound(); // Retorna 404 caso não encontre o consumo de energia
            }

            return Ok(energyUsage); // Retorna 200 com o consumo de energia encontrado
        }

        // GET: api/energyusage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyUsage>>> GetAllEnergyUsagesAsync() {
            var energyUsages = await _energyService.GetAllEnergyUsagesAsync();
            return Ok(energyUsages); // Retorna todos os consumos de energia
        }

        // POST: api/energyusage
        [HttpPost]
        public async Task<ActionResult<EnergyUsage>> AddEnergyUsageAsync([FromBody] EnergyUsage energyUsage) {
            if (energyUsage == null) {
                return BadRequest("O consumo de energia não pode ser nulo.");
            }

            await _energyService.AddEnergyUsageAsync(energyUsage);
            return CreatedAtAction(nameof(GetEnergyUsageByIdAsync), new { id = energyUsage.Id }, energyUsage); // Retorna 201 (Created) com o recurso criado
        }

        // PUT: api/energyusage/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnergyUsageAsync(int id, [FromBody] EnergyUsage energyUsage) {
            if (energyUsage == null || id != energyUsage.Id) {
                return BadRequest("Consumo de energia inválido.");
            }

            await _energyService.UpdateEnergyUsageAsync(energyUsage);
            return NoContent(); // Retorna 204 (No Content) quando a atualização é bem-sucedida
        }

        // DELETE: api/energyusage/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnergyUsageAsync(int id) {
            var energyUsage = await _energyService.GetEnergyUsageByIdAsync(id);
            if (energyUsage == null) {
                return NotFound(); // Retorna 404 se o consumo de energia não for encontrado
            }

            await _energyService.DeleteEnergyUsageAsync(id);
            return NoContent(); // Retorna 204 (No Content) quando a exclusão é bem-sucedida
        }

        // POST: api/energyusage/predictEnergyUsage
        [HttpPost("predictEnergyUsage")]
        public ActionResult<double> PredictEnergyUsage([FromBody] PredictionInput predictionInput) {
            try {
                var predictedUsage = _energyService.PredictEnergyUsage(predictionInput.PreviousUsage);
                return Ok(predictedUsage); // Retorna o valor previsto de consumo de energia
            }
            catch (Exception ex) {
                return BadRequest($"Erro: {ex.Message}"); // Caso ocorra algum erro
            }
        }
    }
}
