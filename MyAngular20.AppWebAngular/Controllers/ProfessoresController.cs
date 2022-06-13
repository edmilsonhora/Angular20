using Microsoft.AspNetCore.Mvc;
using MyAngular20.ApplicationService;
using MyAngular20.ApplicationService.Views;
using System;

namespace MyAngular20.AppWebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IFacade _facade;
        public ProfessoresController(IFacade facade)
        {
            this._facade = facade;
        }


        [Route("obterTodos"), HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_facade.Professores.ObterTodos());
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

                return Ok(_facade.Professores.ObterPaginado(pageIndex, pageSize));
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
                return Ok(_facade.Professores.ObterPor(id));
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }


        [Route("salvar"), HttpPost]
        public IActionResult Salvar(ProfessorView view)
        {
            try
            {
                _facade.Professores.Salvar(view);
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
                _facade.Professores.Excluir(id);
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
