using Controle_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IManutencaoRep{
        Task cadastrarManutencao();
        Task excluirManutencao();
        Task adicionarItem(Item i);
        Task removerItem();

}