namespace Gerenciador_Manutencao.Model;

public class Manutencao
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public int Recorrencia { get; set; }
    public string Status { get; set; }
    public List<Item> Itens { get; set; } = new List<Item>();
}
    
