using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IOrdemServicoRep{
        Task abrirOrdemServico(DateTime data);
         Task fecharOrdemServico(DateTime data);
        Task <List<Item>> listarItens();


}