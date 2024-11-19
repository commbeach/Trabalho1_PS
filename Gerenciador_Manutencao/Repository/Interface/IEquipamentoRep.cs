using Controle_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IEquipamentoRep{
        Task cadastrarEquipamento();
        Task excluirEquipamento();
        Task informarHorimentroOuOdometro(int horaOuKm);
        Task listarManutencoes();
}