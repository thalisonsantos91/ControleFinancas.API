using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.DTO.Apagar;
using ControleFinancas.API.DTO.Usuario;

namespace ControleFinancas.API.AutoMapper
{
    public class ApagarProfile : Profile
    {
        public ApagarProfile()
        {
            CreateMap<Apagar, ApagarRequestContract>().ReverseMap();
            CreateMap<Apagar, ApagarResponseContract>().ReverseMap();
        }
    }
}