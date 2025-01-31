using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Manutencao.Service{
    public interface IOrdemServicoService{

        Task AbrirOrdemServico(OrdemServicoRequestDTO ordemServicoDto);
         Task FecharOrdemServico();
         Task AdicionarItem((Item Item, int Quantidade) itemQuantidade);
         Task RemoverItem(Item item);
         Task<List<(Item Item, int Quantidade)>> ListarItens();

    }
}


