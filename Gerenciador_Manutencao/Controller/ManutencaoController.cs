using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller;

[ApiController]
[Route("api/[controller]")]
public class ManutencaoController : ControllerBase
{
    private readonly IManutencaoRep _manutencaoRep;

    public ManutencaoController(IManutencaoRep manutencaoRep)
    {
        _manutencaoRep = manutencaoRep;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterManutencao(int id)
    {
        
        var manutencao = await _manutencaoRep.ObterManutencaoPorId(id);
        return Ok(manutencao);
        
    }
    
    [HttpPost]
    public async Task<IActionResult> CadastrarManutencao( ManutencaoDTO manutencaoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var manutencao = new Manutencao 
        {
            Tipo = manutencaoDto.Tipo,
            Recorrencia = manutencaoDto.Recorrencia,
            Status = manutencaoDto.Status
        };

        
        await _manutencaoRep.cadastrarManutencao(manutencao);
        return CreatedAtAction(nameof(ObterManutencao), new { id = manutencao.Id }, manutencao);
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirManutencao(int id)
    {
        
        await _manutencaoRep.excluirManutencao(id);
        return NoContent();
        
    }

    [HttpPost("{manutencaoId}/item")]
    public async Task<IActionResult> AdicionarItem(int manutencaoId, [FromBody] Item item)
    {
        await _manutencaoRep.adicionarItem(manutencaoId, item);
        return Ok();
        
    }

    [HttpDelete("{manutencaoId}/item/{itemId}")]
    public async Task<IActionResult> RemoverItem(int manutencaoId, int itemId)
    {
        
        await _manutencaoRep.removerItem(manutencaoId, itemId);
        return NoContent();
            
    }
    
}