using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
namespace Gerenciador_Manutencao.Repository.Implementacao;

public class OrdemServicoRep : IOrdemServicoRep
{
    private readonly AppDbContext _context;

    public OrdemServicoRep(AppDbContext context)
    {
        _context = context;
    }
}