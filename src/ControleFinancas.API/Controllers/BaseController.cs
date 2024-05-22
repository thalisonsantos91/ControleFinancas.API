using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ControleFinancas.API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ControleFinancas.API.Controllers
{
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected int _idUsuario; 
        protected int ObterIdUsuarioLogado()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            int.TryParse(id, out int idUsuario);

            return idUsuario;
        }

        protected ModelErrorContract RetornarModelBadRequest(Exception ex)
        {
            return new ModelErrorContract {
                Status = 400,
                Title = "Bad Request",
                Message = ex.Message,
                DateTime = DateTime.Now
            };
        }

        protected ModelErrorContract RetornarModelNotFound(Exception ex)
        {
            return new ModelErrorContract {
                Status = 404,
                Title = "Not Found",
                Message = ex.Message,
                DateTime = DateTime.Now
            };
        }

        protected ModelErrorContract RetornarModelUnauthorized(Exception ex)
        {
            return new ModelErrorContract {
                Status = 401,
                Title = "Unauthorized",
                Message = ex.Message,
                DateTime = DateTime.Now
            };
        }        

    }
}