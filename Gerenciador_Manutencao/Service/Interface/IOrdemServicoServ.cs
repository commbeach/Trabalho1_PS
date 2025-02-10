using Controle_Manutencao.Repository;
using Gerenciador_Manutencao.Model;
using Gerenciador_Manutencao.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Manutencao.Service{
    public interface IOrdemServicoService{

        Task AbrirOrdemServico(OrdemServicoRequestDTO ordemServicoDto);
         Task FecharOrdemServico();
         Task<List<OrdemServicoResponseDTO>> ListarOrdemServico();
         Task<OrdemServicoResponseDTO> ObterOrdemServ(int id);

    }
}


