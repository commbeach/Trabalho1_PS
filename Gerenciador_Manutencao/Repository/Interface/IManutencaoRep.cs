using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IManutencaoRep{
        Task cadastrarManutencao(Manutencao manutencao);
        Task excluirManutencao(int id);
        Task adicionarItem(int manutencaoId,int itemId);
        Task removerItem(int manutencaoId,int i);
        
        Task<Manutencao> ObterManutencaoPorId(int id);

}