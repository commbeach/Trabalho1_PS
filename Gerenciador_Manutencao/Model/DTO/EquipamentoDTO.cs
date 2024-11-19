using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class EquipamentoDTO
{
    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "O horímetro ou odômetro é obrigatório")]
    public int HorimetroOuOdometro { get; set; }
}
