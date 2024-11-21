using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_Manutencao.Controller;

[ApiController]
[Route("api/[controller]")]
public class OrdemServicoController : ControllerBase
{
    private readonly IOrdemServicoRep _ordemServicoRep;

    public OrdemServicoController(IOrdemServicoRep ordemServicoRep)
    {
        _ordemServicoRep = ordemServicoRep;
    }

    [HttpPost("abrir")]
    public async Task<IActionResult> AbrirOrdemServico([FromBody] OrdemServicoDTO ordemServicoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var ordemServico = new OrdemServico
            {
                idEquipamento = ordemServicoDto.idEquipamento,
                tipo = ordemServicoDto.tipo,
                dataAbertura = DateTime.Now,
                status = "Aberta"
            };

            await _ordemServicoRep.abrirOrdemServico(ordemServico.dataAbertura);
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
            await _ordemServicoRep.fecharOrdemServico(DateTime.Now);
            return Ok("Ordem de serviço fechada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao fechar ordem de serviço: {ex.Message}");
        }
    }

    [HttpPost("item")]
    public async Task<IActionResult> AdicionarItem([FromBody] Item item)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _ordemServicoRep.adicionarItem(item);
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
            await _ordemServicoRep.removerItem(item);
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
            var itens = await _ordemServicoRep.listarItens();
            return Ok(itens);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao listar itens: {ex.Message}");
        }
    }
}