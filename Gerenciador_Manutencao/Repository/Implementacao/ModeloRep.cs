using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Controle_Manutencao.Model;
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

    public async Task<List<Equipamento>> ListarEquipamentos(int modeloId)
    {
        try
        {
            var modelo = await _context.Modelos

                .Include(m => m.Equipamentos)

                .FirstOrDefaultAsync(m => m.Id == modeloId);

            if (modelo == null)
                throw new Exception("Modelo nao encontrado");

            return modelo.Equipamentos.ToList();

        }
        catch (Exception ex)
        {

            throw new Exception($"Erro ao listar equipamentos : {ex.Message}");
        }
    }
}