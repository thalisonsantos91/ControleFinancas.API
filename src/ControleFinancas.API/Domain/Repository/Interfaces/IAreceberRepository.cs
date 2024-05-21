using ControleFinancas.API.Damain.Models;

namespace ControleFinancas.API.Domain.Repository.Interfaces
{
    public interface IAreceberRepository: IRepository<Areceber, int>
    {
        Task<IEnumerable<Areceber>> ObterPeloIdUsuario(int idUsuario);
    }
}