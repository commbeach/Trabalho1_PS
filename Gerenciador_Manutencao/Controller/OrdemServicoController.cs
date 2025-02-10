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

    


    [HttpGet]
    public async Task<IActionResult> ListarOrdemServico()
        {
            var ordemservico= await _ordemServicoService.ListarOrdemServico();
            return Ok(ordemservico);
        }    

   
    [HttpGet("{id}")]
    public async Task<IActionResult> ObterporId(int id)
        {
            var ordemservico= await _ordemServicoService.ObterOrdemServ(id);
            return Ok(ordemservico);
        }    
    }
