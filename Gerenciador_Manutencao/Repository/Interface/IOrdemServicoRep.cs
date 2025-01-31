using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IOrdemServicoRep{
        Task abrirOrdemServico(DateTime data);
        Task fecharOrdemServico(DateTime data);
        Task adicionarItem(Item item, int quantidade);
        Task removerItem(Item item);
        Task<List<(Item Item, int Quantidade)>> listarItens();


}