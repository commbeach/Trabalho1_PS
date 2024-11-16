using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
namespace Gerenciador_Manutencao.Repository.Implementacao;

public class ItemRep : IItemRep
{
    private readonly AppDbContext _context;

    public ItemRepRep(AppDbContext context)
    {
        _context = context;
    }
}