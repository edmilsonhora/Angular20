﻿using Microsoft.AspNetCore.Mvc;
using MyAngular20.ApplicationService;
using MyAngular20.ApplicationService.Views;
using System;

namespace MyAngular20.AppWebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IFacade _facade;
        public UsuariosController(IFacade facade)
        {
            this._facade = facade;
        }

        [Route("obterPor/{nomeUsuario}"), HttpGet]
        public IActionResult ObterPor(string nomeUsuario)
        {
            try
            {
                var usuario = _facade.Usuarios.ObterPor(nomeUsuario);
                _facade.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message);
            }
        }

        [Route("obterTodos"), HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_facade.Usuarios.ObterTodos());
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }


        [Route("obterPaginado/{pageIndex:int}/{pageSize:int}"), HttpGet]
        public IActionResult ObterPaginado(int pageIndex, int pageSize)
        {
            try
            {

                return Ok(_facade.Usuarios.ObterPaginado(pageIndex, pageSize));
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }


        [Route("obterPor/{id:int}"), HttpGet]
        public IActionResult ObterPor(int id)
        {
            try
            {
                return Ok(_facade.Usuarios.ObterPor(id));
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }


        [Route("salvar"), HttpPost]
        public IActionResult Salvar(UsuarioView view)
        {
            try
            {
                _facade.Usuarios.Salvar(view);
                _facade.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }

        [Route("excluir/{id:int}"), HttpDelete]
        public IActionResult Excluir(int id)
        {
            try
            {
                _facade.Usuarios.Excluir(id);
                _facade.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }

       

    }
}
