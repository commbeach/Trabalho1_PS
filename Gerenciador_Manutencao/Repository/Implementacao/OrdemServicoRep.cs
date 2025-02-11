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

    public async Task abrirOrdemServico(OrdemServico ordemServico)
    {
        try
        {

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


    public async Task<List<OrdemServico>> ListarOrdemServico()
    {
        try 
        {
        return await _context.OrdemServicos
         .ToListAsync();
        
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar manutenção: {ex.Message}");
        }
    }

     
    public async Task<OrdemServico> ObterOrdemServicoPorId(int id)
    {
        try 
        {
            var ordemservico = await _context.OrdemServicos
                .FirstOrDefaultAsync(m => m.Id == id);
        
            if (ordemservico == null)
                throw new Exception("Ordem Servico não encontrada");
        
            return ordemservico;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar Ordem de Servico: {ex.Message}");
        }
    }

    


}