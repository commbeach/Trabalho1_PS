using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IModeloRep{
        Task cadastrarModelo(Modelo modelo);
        Task excluirModelo(int id);
        Task <List<Manutencao>> listarManutencoes(int id);
        Task <List<Equipamento>> listarEquipamentos(int id);

}