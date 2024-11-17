using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Controle_Manutencao.Model;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_Manutencao.Repository.Implementacao;

public class ItemRep : IItemRep
{
    private readonly AppDbContext _context;

    public ItemRep(AppDbContext context)
    {
        _context = context;
    }

    public async Task cadastrarItem(Item item)
    {
        try
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            await _context.Itens.AddAsync(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Erro ao cadastrar item: {ex.Message}");

        }
    }

    public async Task excluirItem(int id)
    {
        try
        {
            var item = await _context.Itens

                .FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                throw new Exception("Item nao encontrado");

            _context.Itens.Remove(item);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao excluir item: {ex.Message}");
        }
    }
}