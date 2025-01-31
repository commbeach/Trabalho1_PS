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
                status = "Aberta"
            };

            await _ordemServicoRep.abrirOrdemServico(ordemServico.dataAbertura);
    }

    public async Task FecharOrdemServico()
    {
            await _ordemServicoRep.fecharOrdemServico(DateTime.Now);       
    }

    public async Task AdicionarItem((Item Item, int Quantidade) itemQuantidade)
    {
            await _ordemServicoRep.adicionarItem(itemQuantidade.Item, itemQuantidade.Quantidade);
    }

    public async Task RemoverItem(Item item)
    {
            await _ordemServicoRep.removerItem(item); 
    }

    public async Task<List<(Item Item, int Quantidade)>> ListarItens()
    {
            var itens = await _ordemServicoRep.listarItens();
            return itens;
      
    }
}