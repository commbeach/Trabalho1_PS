namespace Gerenciador_Manutencao.Model;

public class Equipamento
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public Modelo Modelo{ get; set; }
    public int HorimetroOuOdometro { get; set; }
    
}