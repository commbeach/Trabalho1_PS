using System.ComponentModel.DataAnnotations;

namespace Gerenciador_Manutencao.Model.DTO;

public class ItemDTO
{
    [Required(ErrorMessage = "O tipo é obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "A unidade de medida é obrigatória")]
    public int UnidadeDeMedida { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }

}
