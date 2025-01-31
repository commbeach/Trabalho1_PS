using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Gerenciador_Manutencao.Model;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_Manutencao.Repository.Implementacao;

public class OrdemServicoRep : IOrdemServicoRep
{
    private readonly AppDbContext _context;

    public OrdemServicoRep(AppDbContext context)
    {
        _context = context;
    }

    public async Task abrirOrdemServico(DateTime data)
    {
        try
        {
            var ordemServico = new OrdemServico
            {
                dataAbertura = data,
                status = "Aberta",
                Itens = new List<(Item, int)>()
            };

            await _context.OrdemServicos.AddAsync(ordemServico);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao abrir ordem de serviço: {ex.Message}");
        }
    }

    public async Task fecharOrdemServico(DateTime data)
    {
        try
        {
            var ordemServico = await _context.OrdemServicos
                .Where(o => o.status == "Aberta")
                .OrderByDescending(o => o.dataAbertura)
                .FirstOrDefaultAsync();

            if (ordemServico == null)
                throw new Exception("Não foi encontrada nenhuma ordem de serviço aberta");

            ordemServico.status = "Fechada";
            ordemServico.dataFinalizacao = data;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao fechar ordem de serviço: {ex.Message}");
        }
    }

    public async Task adicionarItem(Item item, int quantidade)
    {
        try
        {
            var ordemServico = await _context.OrdemServicos
                .Include(o => o.Itens)
                .Where(o => o.status == "Aberta")
                .OrderByDescending(o => o.dataAbertura)
                .FirstOrDefaultAsync();

            if (ordemServico == null)
                throw new Exception("Não foi encontrada nenhuma ordem de serviço aberta");

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero");

            ordemServico.Itens.Add((item, quantidade));
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao adicionar item: {ex.Message}");
        }
    }

    public async Task removerItem(Item item)
    {
        try
        {
            var ordemServico = await _context.OrdemServicos
                .Include(o => o.Itens)
                .Where(o => o.status == "Aberta")
                .OrderByDescending(o => o.dataAbertura)
                .FirstOrDefaultAsync();

            if (ordemServico == null)
                throw new Exception("Não foi encontrada nenhuma ordem de serviço aberta");

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var itemParaRemover = ordemServico.Itens.FirstOrDefault(i => i.Item.Id == item.Id);
            ordemServico.Itens.Remove(itemParaRemover);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao remover item: {ex.Message}");
        }
    }

    public async Task<List<(Item Item, int Quantidade)>> listarItens()
    {
        try
        {
            var ordemServico = await _context.OrdemServicos
                .Include(o => o.Itens)
                .Where(o => o.status == "Aberta")
                .OrderByDescending(o => o.dataAbertura)
                .FirstOrDefaultAsync();

            if (ordemServico == null)
                return new List<(Item, int)>();

            return ordemServico.Itens;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar itens: {ex.Message}");
        }
    }
}