using Controle_Manutencao.Service;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterModelo(int id)
        {
            var modelo = await _modeloService.ObterModelo(id);
            return Ok(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarModelo(ModeloRequestDTO modeloDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modelo = await _modeloService.CadastrarModelo(modeloDto);
            return CreatedAtAction(nameof(ObterModelo), new { id = modelo.Id }, modelo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirModelo(int id)
        {
            await _modeloService.ExcluirModelo(id);
            return NoContent();
        }

        [HttpGet("{id}/equipamentos")]
        public async Task<IActionResult> ListarEquipamentos(int id)
        {
            var equipamentos = await _modeloService.ListarEquipamentos(id);
            return Ok(equipamentos);
        }

        [HttpGet("{id}/manutencoes")]
        public async Task<IActionResult> ListarManutencoes(int id)
        {
            var manutencoes = await _modeloService.ListarManutencoes(id);
            return Ok(manutencoes);
        }
    }
}
