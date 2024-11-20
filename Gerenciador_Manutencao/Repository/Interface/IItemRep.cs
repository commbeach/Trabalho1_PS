using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IItemRep{

        Task cadastrarItem(Item item);
        Task excluirItem(int id);
        Task<Item> ObterItemPorId(int id);

}