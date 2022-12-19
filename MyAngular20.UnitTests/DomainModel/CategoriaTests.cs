using Moq;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyAngular20.UnitTests.DomainModel
{
    public class CategoriaTests
    {
        [Fact]
        public void Test()
        {
            var sut = new Categoria();
            sut.Nome = "";
            sut.AtualizadoPor = "Edmilson";
            sut.RegistraAlteracao();

            sut.Repository = _repository.Object;
            _repository.Setup(c => c.NomeConferenciaExiste(It.IsAny<Categoria>())).Returns(false);

            var r = Assert.Throws<ApplicationException>(() => sut.Validar());
            var msg = $"O campo {nameof(sut.Nome)} é obrigatório.{Environment.NewLine}";
            Assert.Equal(msg, r.Message);

        }

        private readonly Mock<ICategoriaRepository> _repository = new();
    }
}
