using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAngular20.ApplicationService.Views;
using System.IO;
using MyAngular20.ApplicationService;

namespace MyAngular20.AppWebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IFacade _facade;

        public ProdutosController(IFacade facade)
        {
            this._facade = facade;
        }

        [HttpPost]
        [Route("salvar")]
        public ActionResult Salvar([FromForm] IFormCollection files)
        {
            try
            {

                files.TryGetValue("produto", out StringValues produto);
                var pv = JsonSerializer.Deserialize<ProdutoView>(produto, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var listaFotos = new List<ProdutoFotoView>();
                foreach (var item in files.Files)
                {
                    var foto = new ProdutoFotoView();
                    foto.Bytes = ObterArray(item);
                    foto.MymeType = item.ContentType;
                    foto.NomeArquivo = Path.GetFileNameWithoutExtension(item.FileName);
                    foto.Extensao = Path.GetExtension(item.FileName);
                    foto.Tamanho = item.Length;
                    foto.Principal = false;
                    foto.AtualizadoPor = pv.AtualizadoPor;
                    listaFotos.Add(foto);
                }

                _facade.Produtos.Salvar(pv, listaFotos);
                _facade.SaveChanges();

                return Ok(true);
            }
            catch (Exception ex)
            {
                _facade.Roolback();
                return BadRequest(ex.Message);
            }

        }

        private byte[] ObterArray(IFormFile item)
        {
            using (var ms = new MemoryStream())
            {
                item.CopyTo(ms);

                return ms.ToArray();
            };
        }

        [HttpGet]
        [Route("getImageBy/{id:int}")]
        [ResponseCache(VaryByQueryKeys = new string[] { "id" }, Duration = 120)]
        public FileResult ObterImagemPor(int id)
        {
            byte[] bb = new byte[4];
            try
            {
                return File(bb, "content-type", "Nome");
            }
            catch
            {
                return null;
            }
        }


        [Route("obterTodos"), HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_facade.Produtos.ObterTodos());
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

                return Ok(_facade.Produtos.ObterPaginado(pageIndex, pageSize));
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
                return Ok(_facade.Produtos.ObterPor(id));
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
                _facade.Produtos.Excluir(id);
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

