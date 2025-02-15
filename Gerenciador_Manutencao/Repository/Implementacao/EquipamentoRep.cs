using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Data;
using Gerenciador_Manutencao.Model;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_Manutencao.Repository.Implementacao;

public class EquipamentoRep : IEquipamentoRep
{
    private readonly AppDbContext _context;

    public EquipamentoRep(AppDbContext context)
    {
        _context = context;
    }

    public async Task <List<Equipamento>> listarTodosEquipamentos(){
        return await _context.Equipamentos
            .ToListAsync();

    }
    public async Task cadastrarEquipamento(Equipamento equipamento)
    {
        try
        {
            if (equipamento == null)
                throw new ArgumentNullException(nameof(equipamento));

            await _context.Equipamentos.AddAsync(equipamento);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao cadastrar equipamento: {ex.Message}");
        }
    }

    public async Task excluirEquipamento(int id)
    {
        try
        {
            var equipamento = await _context.Equipamentos
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipamento == null)
                throw new Exception("Equipamento não encontrado");

            _context.Equipamentos.Remove(equipamento);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao excluir equipamento: {ex.Message}");
        }
    }

    public async Task informarHorimentroOuOdometro(int id, int horaOuKm)
    {
        try
        {
            var equipamento = await _context.Equipamentos
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipamento == null)
                throw new Exception("Equipamento não encontrado");

            equipamento.HorimetroOuOdometro = horaOuKm;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar horimetro/odometro: {ex.Message}");
        }
    }

    public async Task<List<Manutencao>> listarManutencoes(int id)
    {
        ModeloRep modeloRep = new ModeloRep(_context);
        try
        {
            var equipamento = await _context.Equipamentos
                .Include(e => e.IdModelo)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipamento == null)
                throw new Exception("Equipamento nao encontrado");

            return await modeloRep.listarManutencoes(equipamento.IdModelo);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar equipamentos : {ex.Message}");
        }
    }

    public async Task<List<Equipamento>> listarEquipamentos(int modeloId)
    {
        try
        {
            return await _context.Equipamentos
            .Where(e => e.IdModelo == modeloId)
            .ToListAsync();
        }
        
        catch (Exception ex)
        {

            throw new Exception($"Erro ao listar equipamentos : {ex.Message}");
        }


        
    }

    public async Task<Equipamento> ObterEquipamentoPorId(int id)
    {
        try 
        {
            var equipamento = await _context.Equipamentos
                .FirstOrDefaultAsync(m => m.Id == id);
        
            if (equipamento == null)
                throw new Exception("Equipamento não encontrado");
        
            return equipamento;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar equipamento: {ex.Message}");
        }
    }



}
