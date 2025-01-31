using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;

namespace Controle_Manutencao.Service
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRep _modeloRep;

        public ModeloService(IModeloRep modeloRep)
        {
            _modeloRep = modeloRep;
        }

        public async Task<ModeloResponseDTO> ObterModelo(int id)
        {
            var modelo = await _modeloRep.ObterModeloPorId(id);
            return new ModeloResponseDTO
            {
                Id = modelo.Id,
                Tipo = modelo.Tipo,
                Marca = modelo.Marca
            };
        }

        public async Task<ModeloResponseDTO> CadastrarModelo(ModeloRequestDTO modeloDto)
        {
            var modelo = new Modelo
            {
                Tipo = modeloDto.Tipo,
                Marca = modeloDto.Marca
            };

            await _modeloRep.cadastrarModelo(modelo);

            return new ModeloResponseDTO
            {
                Id = modelo.Id,
                Tipo = modelo.Tipo,
                Marca = modelo.Marca
            };
        }

        public async Task ExcluirModelo(int id)
        {
            await _modeloRep.excluirModelo(id);
        }

        public async Task<List<Equipamento>> ListarEquipamentos(int modeloId)
        {
            return await _modeloRep.listarEquipamentos(modeloId);
        }

        public async Task<List<Manutencao>> ListarManutencoes(int modeloId)
        {
            return await _modeloRep.listarManutencoes(modeloId);
        }
    }
}