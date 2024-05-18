using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.DTO.Apagar;

namespace ControleFinancas.API.Domain.Services.Interfaces
{
    public interface IApagarService : IService<ApagarRequestContract, ApagarResponseContract, int>{}
}