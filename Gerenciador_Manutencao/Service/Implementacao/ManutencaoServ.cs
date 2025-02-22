using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;

namespace Controle_Manutencao.Service
{
    public class ManutencaoService : IManutencaoService
    {
        private readonly IManutencaoRep _manutencaoRep;

        public ManutencaoService(IManutencaoRep manutencaoRep)
        {
            _manutencaoRep = manutencaoRep;
        }

        public async Task<ManutencaoResponseDTO> ObterManutencao(int id)
        {
            var manutencao = await _manutencaoRep.ObterManutencaoPorId(id);
            return new ManutencaoResponseDTO
            {
                Id = manutencao.Id,
                Tipo = manutencao.Tipo,
                Recorrencia = manutencao.Recorrencia,
                Status = manutencao.Status,
                Itens = manutencao.Itens
            };
        }

         public async Task<List<ManutencaoResponseDTO>> ListarManutencao()
        {
            var manutencao = await _manutencaoRep.ListarManutencao();
            return manutencao.Select(m => new ManutencaoResponseDTO
            {
               Id = m.Id,
                Tipo = m.Tipo,
                Recorrencia = m.Recorrencia,
                Status = m.Status,
                Itens = m.Itens
            }).ToList();
        }

        public async Task<ManutencaoResponseDTO> CadastrarManutencao(ManutencaoRequestDTO manutencaoDto)
        {
            var manutencao = new Manutencao
            {
                Tipo = manutencaoDto.Tipo,
                Recorrencia = manutencaoDto.Recorrencia,
                Status = manutencaoDto.Status
            };

            await _manutencaoRep.cadastrarManutencao(manutencao);

            return new ManutencaoResponseDTO
            {
                Id = manutencao.Id,
                Tipo = manutencao.Tipo,
                Recorrencia = manutencao.Recorrencia,
                Status = manutencao.Status
            };
        }

        public async Task ExcluirManutencao(int id)
        {
            await _manutencaoRep.excluirManutencao(id);
        }

        public async Task AdicionarItem(int manutencaoId, int item)
        {
            await _manutencaoRep.adicionarItem(manutencaoId, item);
        }

        public async Task RemoverItem(int manutencaoId, int itemId)
        {
            await _manutencaoRep.removerItem(manutencaoId, itemId);
        }
    }
}
