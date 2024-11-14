namespace Controle_Manutencao.Model;

public class Modelo
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string Marca { get; set; }
    public List<Manutencao> Manutencoes { get; set; } = new List<Manutencao>();
}
    
