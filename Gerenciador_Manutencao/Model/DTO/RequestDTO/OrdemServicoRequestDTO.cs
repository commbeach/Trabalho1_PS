namespace Gerenciador_Manutencao.Model.DTO;
public class OrdemServicoRequestDTO
{
     public string Tipo { get; set; }
    public string Marca { get; set; }
    public int idEquipamento { get; set; }
     public int idManutencao { get; set; }
    public List<Manutencao> Manutencoes { get; set; } = new List<Manutencao>();
}