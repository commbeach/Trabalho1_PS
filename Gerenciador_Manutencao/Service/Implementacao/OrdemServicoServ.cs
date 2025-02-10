using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Manutencao.Service;

public class OrdemServicoService : IOrdemServicoService
{
    private readonly IOrdemServicoRep _ordemServicoRep;

    public OrdemServicoService(IOrdemServicoRep ordemServicoRep)
    {

        _ordemServicoRep = ordemServicoRep;
    }

    public async Task AbrirOrdemServico(OrdemServicoRequestDTO ordemServicoDto)
    {
      
            var ordemServico = new OrdemServico
            {
                idEquipamento = ordemServicoDto.idEquipamento,
                dataAbertura = DateTime.Now,
                status = "Aberta",
                idManutencao = ordemServicoDto.idManutencao
            };

            await _ordemServicoRep.abrirOrdemServico(ordemServico);
    }

    public async Task FecharOrdemServico()
    {
            await _ordemServicoRep.fecharOrdemServico(DateTime.Now);       
    }



        public async Task<List<OrdemServicoResponseDTO>> ListarOrdemServico()
{
        var ordemservico = await _ordemServicoRep.ListarOrdemServico();
        return ordemservico.Select(m => new OrdemServicoResponseDTO
        {
        Id = m.Id,
        status= m.status,
        idEquipamento= m.idEquipamento,
        idManutencao = m.idManutencao,
        dataAbertura = m.dataAbertura,
        dataFinalizacao = m.dataFinalizacao

        }).ToList();
}
        public async Task<OrdemServicoResponseDTO> ObterOrdemServ(int id){
             var m =   await _ordemServicoRep.ObterOrdemServicoPorId(id);
             return new OrdemServicoResponseDTO{
                Id = m.Id,
                status= m.status,
                idEquipamento= m.idEquipamento,
                idManutencao = m.idManutencao,
                dataAbertura = m.dataAbertura,
                dataFinalizacao = m.dataFinalizacao

        };

        }
}