using Controle_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IItemRep{
        Task cadastrarItem();
        Task excluirEquipamento();

}