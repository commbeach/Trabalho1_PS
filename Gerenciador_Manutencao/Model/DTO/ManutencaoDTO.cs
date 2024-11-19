using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class ManutencaoDTO
{
    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "A recorrência é obrigatória")]
    public int Recorrencia { get; set; }

    [Required(ErrorMessage = "O status é obrigatório")]
    public string Status { get; set; }
}
