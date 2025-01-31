using Gerenciador_Manutencao.Model.DTO;
using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Service
{
    public interface IModeloService
    {
        Task<ModeloResponseDTO> ObterModelo(int id);
        Task<ModeloResponseDTO> CadastrarModelo(ModeloRequestDTO modeloDto);
        Task ExcluirModelo(int id);
        Task<List<Equipamento>> ListarEquipamentos(int modeloId);
        Task<List<Manutencao>> ListarManutencoes(int modeloId);
    }
}