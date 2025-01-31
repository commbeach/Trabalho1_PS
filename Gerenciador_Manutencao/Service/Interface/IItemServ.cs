using Gerenciador_Manutencao.Model.DTO;

namespace Controle_Manutencao.Service
{
    public interface IItemService
    {
        Task<ItemResponseDTO> ObterItemPorId(int id);
        Task<ItemResponseDTO> CadastrarItem(ItemRequestDTO itemDTO);
        Task ExcluirItem(int id);
    }
}
