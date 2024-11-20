using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IEquipamentoRep{
        Task <List<Equipamento>> listarTodosEquipamentos();
        Task cadastrarEquipamento(Equipamento equipamento);
        Task excluirEquipamento(int id);
        Task informarHorimentroOuOdometro(int id, int horaOuKm);
        Task <List<Manutencao>> listarManutencoes(int id);
}