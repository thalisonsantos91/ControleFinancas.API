using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.DTO.Areceber;
using ControleFinancas.API.DTO.Usuario;

namespace ControleFinancas.API.AutoMapper
{
    public class AreceberProfile : Profile
    {
        public AreceberProfile()
        {
            CreateMap<Areceber, AreceberRequestContract>().ReverseMap();
            CreateMap<Areceber, AreceberResponseContract>().ReverseMap();
        }
    }
}