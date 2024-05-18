using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.DTO.Lancamento;

namespace ControleFinancas.API.Domain.Services.Interfaces
{
    public interface ILancamentoService : IService<LancamentoRequestContract, LancamentoResponseContract, int>{}
}