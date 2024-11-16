using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
namespace Gerenciador_Manutencao.Repository.Implementacao;

public class ManutencaoRep : IManutencaoRep
{
    private readonly AppDbContext _context;

    public ManutencaoRep(AppDbContext context)
    {
        _context = context;
    }
}