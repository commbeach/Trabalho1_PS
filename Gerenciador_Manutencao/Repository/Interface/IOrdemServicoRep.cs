using Gerenciador_Manutencao.Model;

namespace Controle_Manutencao.Repository;

public interface IOrdemServicoRep{
        Task abrirOrdemServico(OrdemServico ordemServico);
        Task fecharOrdemServico(DateTime data);
        Task<List<OrdemServico>> ListarOrdemServico();
        Task<OrdemServico> ObterOrdemServicoPorId(int id);

}