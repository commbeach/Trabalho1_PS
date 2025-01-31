namespace Gerenciador_Manutencao.Model.DTO;
public class OrdemServicoResponseDTO
{
     public int Id { get; set; }
     public string Tipo { get; set; }
    public string Marca { get; set; }
    public List<Manutencao> Manutencoes { get; set; } = new List<Manutencao>();
}