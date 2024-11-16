using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class OrdemServicoDTO
{
    [Required(ErrorMessage = "O ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O ID do equipamento é obrigatório")]
    public int IdEquipamento { get; set; }

    [Required(ErrorMessage = "A data de abertura é obrigatória")]
    public DateTime DataAbertura { get; set; }

    [Required(ErrorMessage = "A data de finalização é obrigatória")]
    public DateTime DataFinalizacao { get; set; }

    [Required(ErrorMessage = "A manutenção é obrigatória")]
    public ManutencaoDTO Manutencao { get; set; }
}