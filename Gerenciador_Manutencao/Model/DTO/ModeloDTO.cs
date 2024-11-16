using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class ModeloDTO
{
    [Required(ErrorMessage = "O ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "A marca é obrigatória")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "A lista de manutenções é obrigatória")]
    public List<ManutencaoDTO> Manutencoes { get; set; } = new List<ManutencaoDTO>();
}