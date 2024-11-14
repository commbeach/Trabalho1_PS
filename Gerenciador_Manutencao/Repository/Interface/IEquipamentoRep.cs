using Controle_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IEnderecoRep{
        Task cadastrarEquipamento();
        Task excluirEquipamento();
        Task informarHorimentroOuOdometro(int horaOuKm);

}