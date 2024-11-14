namespace Controle_Manutencao.Model;

public class Equipamento
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public Modelo modelo{ get; set; }
    public int HorimetroOuOdometro { get; set; }
    
}