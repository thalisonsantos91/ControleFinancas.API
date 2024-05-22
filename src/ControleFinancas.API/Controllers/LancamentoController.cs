using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Lancamento;
using ControleFinancas.API.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.API.Controllers
{
    [ApiController]
    [Route("Lancamento-Contas")]
    public class LancamentoController : BaseController
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService)
        {
            _lancamentoService = lancamentoService;
        }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Adicionar(LancamentoRequestContract contrato)
    {
        try
        {
            return  Created("", await _lancamentoService.Adicionar(contrato, ObterIdUsuarioLogado()));
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
            return Ok(await _lancamentoService.Obter(ObterIdUsuarioLogado()));
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
            return Ok(await _lancamentoService.Obter(id, ObterIdUsuarioLogado()));
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
            await _lancamentoService.Inativar(id, ObterIdUsuarioLogado());
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
    public async Task<IActionResult> Atualizar(int id, LancamentoRequestContract contrato)
    {
        try
        {
            return Ok(await _lancamentoService.Atualizar( contrato, id, ObterIdUsuarioLogado()));
        }
        catch (BadRequestException ex)
        {
          return BadRequest(RetornarModelBadRequest(ex));
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

    }
}