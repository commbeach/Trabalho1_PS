using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller;

[ApiController]
[Route("api/[controller]")]
public class EquipamentoController : ControllerBase
{
    private readonly IEquipamentoRep _equipamentoRep;
    private readonly IModeloRep _modeloRep;

    public EquipamentoController(IEquipamentoRep equipamentoRep, IModeloRep modeloRep)
    {
        _equipamentoRep = equipamentoRep;
        _modeloRep = modeloRep;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Equipamento>>> GetEquipamentos()
    {
        var equipamentos = await _equipamentoRep.listarTodosEquipamentos();
        return Ok(equipamentos);
    }
    
    [HttpPost]
    public async Task<ActionResult> CadastrarEquipamento(EquipamentoDTO equipamentoDTO, int IdModelo)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var m = await _modeloRep.ObterModeloPorId(IdModelo);
        
        var equipamento = new Equipamento
        {
            Tipo = equipamentoDTO.Tipo,
            HorimetroOuOdometro = equipamentoDTO.HorimetroOuOdometro,
            IdModelo = IdModelo
        };

        await _equipamentoRep.cadastrarEquipamento(equipamento);
        return CreatedAtAction(nameof(GetEquipamentos), new { id = equipamento.Id }, equipamento);
        
    }


    
    [HttpDelete("{id}")]
    public async Task<ActionResult> ExcluirEquipamento(int id)
    {
        await _equipamentoRep.excluirEquipamento(id);
        return NoContent();
    }
    
    [HttpPut("{id}/horimetro-ou-odometro")]
    public async Task<ActionResult> AtualizarHorimetroOuOdometro(int id, [FromBody] int horaOuKm)
    {
        await _equipamentoRep.informarHorimentroOuOdometro(id, horaOuKm);
        return NoContent();
    }
    
    [HttpGet("{id}/manutencoes")]
    public async Task<ActionResult<List<Manutencao>>> ListarManutencoes(int id)
    {
        var manutencoes = await _equipamentoRep.listarManutencoes(id);
        return Ok(manutencoes);
    }
}
