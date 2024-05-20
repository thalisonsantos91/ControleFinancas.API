
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Apagar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.API.Controllers
{
    [ApiController]
    [Route("Contas-Apagar")]
    public class ApagarController : BaseController
    {
        private readonly IApagarService _apagarService;

        public ApagarController(IApagarService apagarService)
        {
            _apagarService = apagarService;
        }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Adicionar(ApagarRequestContract contrato)
    {
        try
        {
            return  Created("", await _apagarService.Adicionar(contrato, ObterIdUsuarioLogado()));
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
            return Ok(await _apagarService.Obter(ObterIdUsuarioLogado()));
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
            return Ok(await _apagarService.Obter(id, ObterIdUsuarioLogado()));
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
            await _apagarService.Inativar(id, ObterIdUsuarioLogado());
            return NoContent();
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize]
    public async Task<IActionResult> Atualizar(int id, ApagarRequestContract contrato)
    {
        try
        {
            return Ok(await _apagarService.Atualizar( contrato, id, ObterIdUsuarioLogado()));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }














    }
}