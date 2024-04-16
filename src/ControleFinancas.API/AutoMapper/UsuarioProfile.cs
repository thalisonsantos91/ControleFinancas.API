using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinancas.API.Damain.Models;
using ControleFinancas.API.DTO.Usuario;

namespace ControleFinancas.API.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioRequestContract>().ReverseMap();
            CreateMap<Usuario, UsuarioResponseContract>().ReverseMap();
        }
    }
}