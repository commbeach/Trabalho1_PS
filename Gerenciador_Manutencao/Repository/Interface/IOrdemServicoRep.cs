using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IOrdemServicoRep{
        Task abrirOrdemServico(DateTime data);
        Task fecharOrdemServico(DateTime data);
        Task adicionarItem(Item i);
        Task removerItem(Item i);
        Task <List<Item>> listarItens();
}