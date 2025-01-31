using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Gerenciador_Manutencao.Model;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_Manutencao.Repository.Implementacao;

public class ModeloRep : IModeloRep
{
    private readonly AppDbContext _context;

    public ModeloRep(AppDbContext context)
    {
        _context = context;
    }

    public async Task cadastrarModelo(Modelo modelo)
    {
        try
        {
            if (modelo == null)
                throw new ArgumentNullException(nameof(modelo));

            await _context.Modelos.AddAsync(modelo);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao cadastrar modelo : {ex.Message}");
        }
    }

    public async Task excluirModelo(int id)
    {
        try
        {
            var modelo = await _context.Modelos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modelo == null)
                throw new Exception("Modelo nao encontrado");

            _context.Modelos.Remove(modelo);

            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao excluir modelo : {ex.Message}");
        }
    }

    public async Task<List<Equipamento>> listarEquipamentos(int modeloId)
    {
        try
        {
            return await _context.Equipamentos
            .Where(e => e.Modelo.Id == modeloId)
            .ToListAsync();
        }
        
        catch (Exception ex)
        {

            throw new Exception($"Erro ao listar equipamentos : {ex.Message}");
        }
    }


    public async Task<List<Manutencao>> listarManutencoes(int modeloId)
    {
        try
        {
            return await _context.Modelos
                .Where(e => e.Id == modeloId)
                .SelectMany(u => u.Manutencoes)
                .ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception($"Erro ao listar Manutencoes : {ex.Message}");
        }
    }

    public async Task<Modelo> ObterModeloPorId(int id)
    {
        try 
        {
            var modelo = await _context.Modelos
                .Include(m => m.Manutencoes)
                .FirstOrDefaultAsync(m => m.Id == id);
        
            if (modelo == null)
                throw new Exception("Modelo não encontrado");
        
            return modelo;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar modelo: {ex.Message}");
        }
    }
    
}