using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class OrdemServicoDTO
{
    [Required(ErrorMessage = "A data de abertura é obrigatória")]
    public DateTime DataAbertura { get; set; }

    [Required(ErrorMessage = "O id do equipamento é obrigatório")]
    public int idEquipamento { get; set; }

    [Required(ErrorMessage = "O tipo da manutenção é obrigatório")]
    public string tipo { get; set; }

    [Required(ErrorMessage = "O tipo de manutenção é obrigatório")]
    public string status { get; set; }
}
