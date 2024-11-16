using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
namespace Gerenciador_Manutencao.Repository.Implementacao;

public class ModeloRep : IModeloRep
{
    private readonly AppDbContext _context;

    public ModeloRep(AppDbContext context)
    {
        _context = context;
    }
}