using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class ManutencaoDTO
{
    [Required(ErrorMessage = "O ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "A recorrência é obrigatória")]
    public int Recorrencia { get; set; }

    [Required(ErrorMessage = "O status é obrigatório")]
    public string Status { get; set; }

    [Required(ErrorMessage = "A lista de itens é obrigatória")]
    public List<ItemDTO> Itens { get; set; } = new List<ItemDTO>();
}