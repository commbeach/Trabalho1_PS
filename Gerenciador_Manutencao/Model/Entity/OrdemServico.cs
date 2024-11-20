namespace Gerenciador_Manutencao.Model;

public class OrdemServico
{
    public int Id { get; set; }
    public int idEquipamento { get; set; }
    public DateTime dataAbertura { get; set; }
    public DateTime dataFinalizacao { get; set; }
    public Manutencao Manutencao { get; set; }
}