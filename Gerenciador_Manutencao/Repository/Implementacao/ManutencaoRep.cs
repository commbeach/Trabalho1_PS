using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Controle_Manutencao.Model;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_Manutencao.Repository.Implementacao;

public class ManutencaoRep : IManutencaoRep
{
    private readonly AppDbContext _context;

    public ManutencaoRep(AppDbContext context)
    {
        _context = context;
    }

    public async Task cadastrarManutencao(Manutencao manutencao)
    {
        try
        {
            if (manutencao == null)
                throw new ArgumentNullException(nameof(manutencao));

            await _context.Manutencoes.AddAsync(manutencao);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao cadastrar manutenção: {ex.Message}");
        }
    }

    public async Task excluirManutencao(int id)
    {
        try
        {
            var manutencao = await _context.Manutencoes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manutencao == null)
                throw new Exception("Manutençao nao encontrada");

            _context.Manutencoes.Remove(manutencao);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao excluir manutençao: {ex.Message}");
        }
    }

    public async Task adicionarItem(int manutencaoId, Item item)
    {
        try
        {
            var manutencao = await _context.Manutencoes
                .Include(m => m.Itens)
                .FirstOrDefaultAsync(m => m.Id == manutencaoId);

            if (manutencao == null)

                throw new Exception("Manutençao nao foi encontrada");


            if (item == null)

                throw new ArgumentNullException(nameof(item));

            manutencao.Itens.Add(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao adicionar item: {ex.Message}");
        }
    }

    public async Task removerItem(int manutencaoId, int itemId)
    {
        try
        {
            var manutencao = await _context.Manutencoes
                .Include(m => m.Itens)
                .FirstOrDefaultAsync(m => m.Id == manutencaoId);

            if (manutencao == null)
                throw new Exception("Manutençao nao foi encontrada");

            var item = manutencao.Itens.FirstOrDefault(i => i.Id == itemId);

            if (item == null)
                throw new Exception("Item nao encontrado na manutençao");

            manutencao.Itens.Remove(item);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao remover item : {ex.Message}");
        }
    }
}