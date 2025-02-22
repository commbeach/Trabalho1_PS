using Gerenciador_Manutencao.Model.DTO;
using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Service
{
    public interface IEquipamentoService
    {
        Task<List<EquipamentoResponseDTO>> ListarEquipamentos();
        Task<EquipamentoResponseDTO> CadastrarEquipamento(EquipamentoRequestDTO equipamentoDTO);
        Task ExcluirEquipamento(int id);
        Task AtualizarHorimetroOuOdometro(int id, int horaOuKm);
        Task<List<Manutencao>> ListarManutencoes(int id);
        Task<EquipamentoResponseDTO> ObterEquipamento(int id);
    }
}