using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class EquipamentoDTO
{
    [Required(ErrorMessage = "O ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "O modelo é obrigatório")]
    public ModeloDTO Modelo { get; set; }

    [Required(ErrorMessage = "O horímetro ou odômetro é obrigatório")]
    public int HorimetroOuOdometro { get; set; }
}