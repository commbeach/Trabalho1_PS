using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemRep _itemRep;

    public ItemController(IItemRep itemRep)
    {
        _itemRep = itemRep;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterItem(int id)
    {
        
        var item = await _itemRep.ObterItemPorId(id);
        return Ok(item);
        
    }
    
    [HttpPost]
    public async Task<ActionResult> CadastrarItem(ItemDTO itemDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var item = new Item
        {
            Tipo = itemDTO.Tipo,
            unidadeDeMedida = itemDTO.UnidadeDeMedida,
            descricao = itemDTO.Descricao,
        };

        await _itemRep.cadastrarItem(item);
        return CreatedAtAction(nameof(ObterItem), new { id = item.Id }, item);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirItem(int id)
    {
        await _itemRep.excluirItem(id);
        return NoContent();
    }
}