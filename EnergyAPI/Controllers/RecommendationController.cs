using Microsoft.AspNetCore.Mvc;
using EnergyAPI.Models;
using EnergyAPI.Services.IA;

namespace EnergyAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase {
        private readonly IEnergyService _energyService;

        public RecommendationController(IEnergyService energyService) {
            _energyService = energyService;
        }

        // GET: api/recommendation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Recommendation>> GetRecommendationByIdAsync(int id) {
            var recommendation = await _energyService.GetRecommendationByIdAsync(id);
            if (recommendation == null) {
                return NotFound(); // Retorna 404 se a recomendação não for encontrada
            }

            return Ok(recommendation); // Retorna 200 com a recomendação encontrada
        }

        // GET: api/recommendation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recommendation>>> GetAllRecommendationsAsync() {
            var recommendations = await _energyService.GetAllRecommendationsAsync();
            return Ok(recommendations); // Retorna todas as recomendações
        }

        // POST: api/recommendation
        [HttpPost]
        public async Task<ActionResult<Recommendation>> AddRecommendationAsync([FromBody] Recommendation recommendation) {
            if (recommendation == null) {
                return BadRequest("A recomendação não pode ser nula.");
            }

            await _energyService.AddRecommendationAsync(recommendation);
            return CreatedAtAction(nameof(GetRecommendationByIdAsync), new { id = recommendation.Id }, recommendation); // Retorna 201 (Created) com o recurso criado
        }

        // PUT: api/recommendation/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendationAsync(int id, [FromBody] Recommendation recommendation) {
            if (recommendation == null || id != recommendation.Id) {
                return BadRequest("Recomendação inválida.");
            }

            await _energyService.UpdateRecommendationAsync(recommendation);
            return NoContent(); // Retorna 204 (No Content) quando a atualização é bem-sucedida
        }

        // DELETE: api/recommendation/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendationAsync(int id) {
            var recommendation = await _energyService.GetRecommendationByIdAsync(id);
            if (recommendation == null) {
                return NotFound(); // Retorna 404 se a recomendação não for encontrada
            }

            await _energyService.DeleteRecommendationAsync(id);
            return NoContent(); // Retorna 204 (No Content) quando a exclusão é bem-sucedida
        }
    }
}
