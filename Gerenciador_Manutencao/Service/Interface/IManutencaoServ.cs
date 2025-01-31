using Gerenciador_Manutencao.Model.DTO;
using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Service
{
    public interface IManutencaoService
    {
        Task<ManutencaoResponseDTO> ObterManutencao(int id);
        Task<ManutencaoResponseDTO> CadastrarManutencao(ManutencaoRequestDTO manutencaoDto);
        Task ExcluirManutencao(int id);
        Task AdicionarItem(int manutencaoId, Item item);
        Task RemoverItem(int manutencaoId, int itemId);
    }
}