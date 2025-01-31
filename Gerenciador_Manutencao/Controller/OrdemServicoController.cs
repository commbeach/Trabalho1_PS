using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Controle_Manutencao.Service;

namespace Gerenciador_Manutencao.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrdemServicoController : ControllerBase
{
    private readonly IOrdemServicoService _ordemServicoService;

     public OrdemServicoController(IOrdemServicoService ordemServicoService)
        {
            _ordemServicoService = ordemServicoService;
        }
    [HttpPost("abrir")]
    public async Task<IActionResult> AbrirOrdemServico([FromBody] OrdemServicoRequestDTO ordemServicoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _ordemServicoService.AbrirOrdemServico(ordemServicoDto);

            return Ok("Ordem de serviço aberta com sucesso");
        }
        catch (Exception ex)
        {

            return BadRequest($"Erro ao abrir ordem de serviço: {ex.Message}");
        }
    }

    [HttpPost("fechar")]
    public async Task<IActionResult> FecharOrdemServico()
    {
        try
        {
            await _ordemServicoService. FecharOrdemServico();
            return Ok("Ordem de serviço fechada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao fechar ordem de serviço: {ex.Message}");
        }
    }

    [HttpPost("item")]
    public async Task<IActionResult> AdicionarItem([FromBody] (Item item, int Quantidade) itemQuantidade)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            await _ordemServicoService.AdicionarItem( itemQuantidade);

            return Ok("Item adicionado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar item: {ex.Message}");
        }
    }

    [HttpDelete("item")]
    public async Task<IActionResult> RemoverItem([FromBody] Item item)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _ordemServicoService.RemoverItem(item);

            return Ok("Item removido com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao remover item: {ex.Message}");
        }
    }

    [HttpGet("itens")]
    public async Task<IActionResult> ListarItens()
    {
        try
        {
            var itens = await _ordemServicoService. ListarItens();
            return Ok(itens);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao listar itens: {ex.Message}");
        }
    }
}