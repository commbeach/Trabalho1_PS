namespace Gerenciador_Manutencao.Model;

public class OrdemServico
{
    public int Id { get; set; }
    public int idEquipamento { get; set; }
     public string status { get; set; }
    public DateTime dataAbertura { get; set; }
    public DateTime dataFinalizacao { get; set; }
    public int idManutencao { get; set; }
   
}