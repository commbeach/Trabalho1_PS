using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class OrdemServicoDTO
{
    [Required(ErrorMessage = "A data de abertura é obrigatória")]
    public DateTime DataAbertura { get; set; }

    [Required(ErrorMessage = "A data de finalização é obrigatória")]
    public DateTime DataFinalizacao { get; set; }
}
