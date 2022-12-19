using Moq;
using MyAngular20.ApplicationService.Facades;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAngular20.UnitTests.ApplicationService
{
    public class CategoriaFacadeTests
    {
        [Fact]
        public void Ao_incluir_nova_categoria_com_campo_vazio_deve_lancar_exception()
        {
            var sut = ObterFacade();
            _repository.Setup(c => c.Categorias.ObterPor(It.IsAny<int>())).Returns(new Categoria());
            Assert.Throws<ApplicationException>(() => sut.Salvar(new CategoriaView { Nome = "", AtualizadoPor="edmilson" }));

        }

        [Fact]
        public void Ao_incluir_nova_categoria_com_campo_repetido_deve_lancar_exception()
        {
            var sut = ObterFacade();
            var categoria = new Categoria();

            var valor = "Brinquedos";
            var nomeCampo = nameof(categoria.Nome);

            _repository.Setup(c => c.Categorias.ObterPor(It.IsAny<int>())).Returns(categoria);
            _repository.Setup(c => c.Categorias.NomeConferenciaExiste(It.IsAny<Categoria>())).Returns(true);

           var ret = Assert.Throws<ApplicationException>(() => sut.Salvar(new CategoriaView { Nome = valor, AtualizadoPor = "edmilson" }));
            var msg = $"O valor {valor} já existe na base de dados para o campo {nomeCampo}.{Environment.NewLine}";
            Assert.Equal(msg, ret.Message);

        }

        public ICategoriaFacade ObterFacade()
        {
            return new CategoriaFacade(_repository.Object);
        }



        private readonly Mock<IRepository> _repository = new();
    }
}
