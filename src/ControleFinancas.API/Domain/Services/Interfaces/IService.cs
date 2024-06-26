using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinancas.API.Domain.Services.Interfaces
{
    /// <summary>
    /// Interfale generica para criação de serviços tipo CRUD
    /// </summary>
    /// <typeparam name="RQ"> Contrato de request</typeparam>
    /// <typeparam name="RS"> Contrato de response</typeparam>
    /// <typeparam name="I">Tipo do Id</typeparam> <summary>
    /// 
    /// </summary>
    /// <typeparam name="RQ"></typeparam>
    /// <typeparam name="RS"></typeparam>
    /// <typeparam name="I"></typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Obter(I idUsuario);
        Task<RS> Obter(I id, I idUsuario);
        Task<RS> Adicionar(RQ entidade, I IdUsuario);
        Task<RS> Atualizar(RQ entidade, I id, I idUsuario);
        Task Inativar(I id, I idUsuario);
    }
}