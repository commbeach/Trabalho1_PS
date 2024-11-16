using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class ItemDTO
{
    [Required(ErrorMessage = "O ID é obrigatório")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "A unidade de medida é obrigatória")]
    public int UnidadeDeMedida { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória")]
    [Range(0.01, float.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
    public float Quantidade { get; set; }
}