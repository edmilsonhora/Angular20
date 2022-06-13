using Microsoft.AspNetCore.Mvc;
using MyAngular20.ApplicationService;
using MyAngular20.ApplicationService.Views;
using System;

namespace MyAngular20.AppWebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorariosController : ControllerBase
    {
        private readonly IFacade _facade;
        public HorariosController(IFacade facade)
        {
            this._facade = facade;
        }


        [Route("obterTodos"), HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_facade.Horarios.ObterTodos());
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

                return Ok(_facade.Horarios.ObterPaginado(pageIndex, pageSize));
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
                return Ok(_facade.Horarios.ObterPor(id));
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }


        [Route("salvar"), HttpPost]
        public IActionResult Salvar(HorarioView view)
        {
            try
            {
                _facade.Horarios.Salvar(view);
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
                _facade.Horarios.Excluir(id);
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
