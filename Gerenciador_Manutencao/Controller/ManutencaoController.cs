using Controle_Manutencao.Service;
using Gerenciador_Manutencao.Model.DTO;
using Gerenciador_Manutencao.Model;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManutencaoController : ControllerBase
    {
        private readonly IManutencaoService _manutencaoService;

        public ManutencaoController(IManutencaoService manutencaoService)
        {
            _manutencaoService = manutencaoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterManutencao(int id)
        {
            var manutencao = await _manutencaoService.ObterManutencao(id);
            return Ok(manutencao);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarManutencao(ManutencaoRequestDTO manutencaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var manutencao = await _manutencaoService.CadastrarManutencao(manutencaoDto);
            return CreatedAtAction(nameof(ObterManutencao), new { id = manutencao.Id }, manutencao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirManutencao(int id)
        {
            await _manutencaoService.ExcluirManutencao(id);
            return NoContent();
        }

        [HttpPost("{manutencaoId}/item")]
        public async Task<IActionResult> AdicionarItem(int manutencaoId, [FromBody] Item item)
        {
            await _manutencaoService.AdicionarItem(manutencaoId, item);
            return Ok();
        }

        [HttpDelete("{manutencaoId}/item/{itemId}")]
        public async Task<IActionResult> RemoverItem(int manutencaoId, int itemId)
        {
            await _manutencaoService.RemoverItem(manutencaoId, itemId);
            return NoContent();
        }
    }
}