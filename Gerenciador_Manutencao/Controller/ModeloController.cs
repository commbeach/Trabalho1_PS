using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller;

[ApiController]
[Route("api/[controller]")]
public class ModeloController : ControllerBase
{
    private readonly IModeloRep _modeloRep;

    public ModeloController(IModeloRep modeloRep)
    {
        _modeloRep = modeloRep;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarModelo([FromBody] ModeloDTO modeloDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var modelo = new Modelo 
        {
            Tipo = modeloDto.Tipo,
            Marca = modeloDto.Marca
        };

        
        await _modeloRep.cadastrarModelo(modelo);
        return CreatedAtAction(nameof(ObterModelo), new { id = modelo.Id }, modelo);
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirModelo(int id)
    {
        
        await _modeloRep.excluirModelo(id);
        return NoContent();
        
    }

    [HttpGet("{id}/equipamentos")]
    public async Task<IActionResult> ListarEquipamentos(int id)
    {
       
        var equipamentos = await _modeloRep.listarEquipamentos(id);
        return Ok(equipamentos);
        
    }

    [HttpGet("{id}/manutencoes")]
    public async Task<IActionResult> ListarManutencoes(int id)
    {
        
        var manutencoes = await _modeloRep.listarManutencoes(id);
        return Ok(manutencoes);
        
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterModelo(int id)
    {
        
        var modelo = await _modeloRep.ObterModeloPorId(id);
        return Ok(modelo);
        
    }
}
