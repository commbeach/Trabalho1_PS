namespace Gerenciador_Manutencao.Model;

public class OrdemServico
{
    public int Id { get; set; }
    public int idEquipamento { get; set; }
    public string tipo { get; set; }
    public string status { get; set; }
    public DateTime dataAbertura { get; set; }
    public DateTime dataFinalizacao { get; set; }
    public List<Item> Itens { get; set; } = new List<Item>();
}