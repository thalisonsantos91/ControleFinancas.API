
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Areceber;
using ControleFinancas.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.API.Controllers
{
    [ApiController]
    [Route("Contas-areceber")]
    public class AreceberController : BaseController
    {
        private readonly IAreceberService _areceberService;

        public AreceberController(IAreceberService apagarService)
        {
            _areceberService = apagarService;
        }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Adicionar(AreceberRequestContract contrato)
    {
        try
        {
            return  Created("", await _areceberService.Adicionar(contrato, ObterIdUsuarioLogado()));
        }
        catch (NotFoundException ex)
        {
          return NotFound(RetornarModelNotFound(ex));
        }
        catch (BadRequestException ex)
        {
          return BadRequest(RetornarModelBadRequest(ex));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Obter()
    {
        try
        {
            return Ok(await _areceberService.Obter(ObterIdUsuarioLogado()));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> Obter(int id)
    {
        try
        {
            return Ok(await _areceberService.Obter(id, ObterIdUsuarioLogado()));
        }
        catch (NotFoundException ex)
        {
          return NotFound(RetornarModelNotFound(ex));
        }         
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> Deletar(int id)
    {
        try
        {
            await _areceberService.Inativar(id, ObterIdUsuarioLogado());
            return NoContent();
        }
        catch (NotFoundException ex)
        {
          return NotFound(RetornarModelNotFound(ex));
        } 
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> Atualizar(int id, AreceberRequestContract contrato)
    {
        try
        {
            return Ok(await _areceberService.Atualizar( contrato, id, ObterIdUsuarioLogado()));
        }
        catch (NotFoundException ex)
        {
          return NotFound(RetornarModelNotFound(ex));
        } 
        catch (BadRequestException ex)
        {
          return BadRequest(RetornarModelBadRequest(ex));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }














    }
}