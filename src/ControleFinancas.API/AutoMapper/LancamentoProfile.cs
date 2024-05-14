using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.DTO.NaturezaDeLancamento;
using ControleFinancas.API.DTO.Usuario;

namespace ControleFinancas.API.AutoMapper
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<Lancamento, LancamentoRequestContract>().ReverseMap();
            CreateMap<Lancamento, LancamentoResponseContract>().ReverseMap();
        }
    }
}