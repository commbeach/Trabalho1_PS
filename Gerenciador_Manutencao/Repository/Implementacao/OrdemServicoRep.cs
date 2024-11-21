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
                Itens = new List<Item>()
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

    public async Task adicionarItem(Item i)
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

            if (i == null)
                throw new ArgumentNullException(nameof(i));

            ordemServico.Itens.Add(i);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao adicionar item: {ex.Message}");
        }
    }

    public async Task removerItem(Item i)
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

            if (i == null)
                throw new ArgumentNullException(nameof(i));

            var itemParaRemover = ordemServico.Itens.FirstOrDefault(item => item.Id == i.Id);
            if (itemParaRemover == null)
                throw new Exception("Item não encontrado na ordem de serviço");

            ordemServico.Itens.Remove(itemParaRemover);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao remover item: {ex.Message}");
        }
    }

    public async Task<List<Item>> listarItens()
    {
        try
        {
            var ordemServico = await _context.OrdemServicos
                .Include(o => o.Itens)
                .Where(o => o.status == "Aberta")
                .OrderByDescending(o => o.dataAbertura)
                .FirstOrDefaultAsync();

            if (ordemServico == null)
                return new List<Item>();

            return ordemServico.Itens;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar itens: {ex.Message}");
        }
    }
}