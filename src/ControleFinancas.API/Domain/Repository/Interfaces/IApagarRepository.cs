using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Damain.Models;

namespace ControleFinancas.API.Domain.Repository.Interfaces
{
    public interface IApagarRepository: IRepository<Apagar, int>
    {
        Task<IEnumerable<Apagar>> ObterPeloIdUsuario(int idUsuario);
    }
}