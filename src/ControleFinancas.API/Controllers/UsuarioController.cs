using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinancas.API.Domain.Services.Interfaces;
using ControleFinancas.API.DTO.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.API.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _userService;

        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Adicionar(UsuarioRequestContract contrato)
    {
        try
        {
            return  Created("", await _userService.Adicionar(contrato, 0));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Obter()
    {
        try
        {
            return Ok(await _userService.Obter(0));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Obter(int id)
    {
        try
        {
            return Ok(await _userService.Obter(id, 0));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Deletar(int id)
    {
        try
        {
            await _userService.Inativar(id, 0);
            return NoContent();
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Atualizar(int id, UsuarioRequestContract contrato)
    {
        try
        {
            return Ok(await _userService.Atualizar( contrato, id, 0));
        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }














    }
}