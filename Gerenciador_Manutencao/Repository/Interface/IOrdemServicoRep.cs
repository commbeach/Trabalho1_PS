using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IOrdemServicoRep{
        Task abrirOrdemServico(DateTime data);
        Task fecharOrdemServico(DateTime data);
        Task adicionarItem(Item item);
        Task removerItem(Item item);
        Task<List<Item>> listarItens();


}