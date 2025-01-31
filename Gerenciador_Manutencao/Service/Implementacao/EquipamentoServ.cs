using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;

namespace Controle_Manutencao.Service
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRep _equipamentoRep;

        public EquipamentoService(IEquipamentoRep equipamentoRep)
        {
            _equipamentoRep = equipamentoRep;
        }

        public async Task<List<EquipamentoResponseDTO>> ListarEquipamentos()
        {
            var equipamentos = await _equipamentoRep.listarTodosEquipamentos();
            return equipamentos.Select(e => new EquipamentoResponseDTO
            {
                Id = e.Id,
                Tipo = e.Tipo,
                HorimetroOuOdometro = e.HorimetroOuOdometro,
                Modelo = e.Modelo
            }).ToList();
        }

        public async Task<EquipamentoResponseDTO> CadastrarEquipamento(EquipamentoRequestDTO equipamentoDTO, int idModelo)
        {
            var equipamento = new Equipamento
            {
                Tipo = equipamentoDTO.Tipo,
                HorimetroOuOdometro = equipamentoDTO.HorimetroOuOdometro,
                Modelo = equipamentoDTO.Modelo
            };

            await _equipamentoRep.cadastrarEquipamento(equipamento);

            return new EquipamentoResponseDTO
            {
                Id = equipamento.Id,
                Tipo = equipamento.Tipo,
                HorimetroOuOdometro = equipamento.HorimetroOuOdometro,
                Modelo = equipamento.Modelo
            };
        }

        public async Task ExcluirEquipamento(int id)
        {
            await _equipamentoRep.excluirEquipamento(id);
        }

        public async Task AtualizarHorimetroOuOdometro(int id, int horaOuKm)
        {
            await _equipamentoRep.informarHorimentroOuOdometro(id, horaOuKm);
        }

        public async Task<List<Manutencao>> ListarManutencoes(int id)
        {
            return await _equipamentoRep.listarManutencoes(id);
        }
    }
}