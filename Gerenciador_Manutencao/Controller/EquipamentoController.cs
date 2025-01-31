using Controle_Manutencao.Service;
using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoController(IEquipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipamentoResponseDTO>>> GetEquipamentos()
        {
            var equipamentos = await _equipamentoService.ListarEquipamentos();
            return Ok(equipamentos);
        }

        [HttpPost]
        public async Task<ActionResult<EquipamentoResponseDTO>> CadastrarEquipamento(EquipamentoRequestDTO equipamentoDTO, int idModelo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var equipamento = await _equipamentoService.CadastrarEquipamento(equipamentoDTO, idModelo);
            return CreatedAtAction(nameof(GetEquipamentos), new { id = equipamento.Id }, equipamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirEquipamento(int id)
        {
            await _equipamentoService.ExcluirEquipamento(id);
            return NoContent();
        }

        [HttpPut("{id}/horimetro-ou-odometro")]
        public async Task<ActionResult> AtualizarHorimetroOuOdometro(int id, [FromBody] int horaOuKm)
        {
            await _equipamentoService.AtualizarHorimetroOuOdometro(id, horaOuKm);
            return NoContent();
        }

        [HttpGet("{id}/manutencoes")]
        public async Task<ActionResult<List<Manutencao>>> ListarManutencoes(int id)
        {
            var manutencoes = await _equipamentoService.ListarManutencoes(id);
            return Ok(manutencoes);
        }
    }
}
