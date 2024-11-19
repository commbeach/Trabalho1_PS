using Controle_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IModeloRep{
        Task cadastrarModelo();
        Task excluirModelo();
        Task <List<Manutencao>> listarManutencoes();
        Task <List<Equipamento>> listarEquipamentos();

}