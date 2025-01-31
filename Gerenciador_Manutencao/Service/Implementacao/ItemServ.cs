using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;

namespace Controle_Manutencao.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRep _itemRep;

        public ItemService(IItemRep itemRep)
        {
            _itemRep = itemRep;
        }

        public async Task<ItemResponseDTO> ObterItemPorId(int id)
        {
            var item = await _itemRep.ObterItemPorId(id);
            return new ItemResponseDTO
            {
                Id = item.Id,
                Tipo = item.Tipo,
                UnidadeDeMedida = item.unidadeDeMedida,
                Descricao = item.descricao,
                Quantidade = item.quantidade
            };
        }

        public async Task<ItemResponseDTO> CadastrarItem(ItemRequestDTO itemDTO)
        {
            var item = new Item
            {
                Tipo = itemDTO.Tipo,
                unidadeDeMedida = itemDTO.UnidadeDeMedida,
                descricao = itemDTO.Descricao,
                quantidade = itemDTO.Quantidade
            };

            await _itemRep.cadastrarItem(item);

            return new ItemResponseDTO
            {
                Id = item.Id,
                Tipo = item.Tipo,
                UnidadeDeMedida = item.unidadeDeMedida,
                Descricao = item.descricao,
                Quantidade = item.quantidade
            };
        }

        public async Task ExcluirItem(int id)
        {
            await _itemRep.excluirItem(id);
        }
    }
}