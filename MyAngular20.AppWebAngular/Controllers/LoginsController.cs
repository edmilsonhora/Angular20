using Microsoft.AspNetCore.Mvc;
using MyAngular20.ApplicationService;
using MyAngular20.ApplicationService.Views;
using System;

namespace MyAngular20.AppWebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly IFacade _facade;
        public LoginsController(IFacade facade)
        {
            this._facade = facade;
        }



        [Route("autenticar"), HttpPost]
        public IActionResult Autenticar(LoginDataView loginData)
        {
            try
            {
                this._facade.Logins.Autenticar(loginData);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("checarOuCriarAdmin"), HttpGet]
        public IActionResult ChecarOuCriarAdmin()
        {
            try
            {
                _facade.Usuarios.ChecarOuCriarAdmin();
                _facade.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message.Replace(Environment.NewLine, ";"));
            }
        }
    }
}
