
using Gerenciador_Manutencao.Model;

public class EquipamentoResponseDTO
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public int HorimetroOuOdometro { get; set; }
    public Modelo Modelo { get; set; }
}