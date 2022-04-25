using MyAngular20.ApplicationService.Facades;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DataAccess;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService
{
    public class Facade : IFacade
    {
        private ICategoriaFacade categorias;
        private IClienteFacade clientes;
        private IPedidoFacade pedidos;
        private IProdutoFacade produtos;
        private IUsuarioFacade usuarios;
        private ILoginFacade logins;
        private IUnidadeDeMedidaFacade unidadesDeMedidas;
        private readonly IRepository repository;
        public Facade(string conn = "")
        {
            repository = new Repository();
        }

        ICategoriaFacade IFacade.Categorias => categorias ?? (categorias = new CategoriaFacade(repository));

        IClienteFacade IFacade.Clientes => clientes ?? (clientes = new ClienteFacade(repository));

        IUsuarioFacade IFacade.Usuarios => usuarios ?? (usuarios = new UsuarioFacade(repository));

        IProdutoFacade IFacade.Produtos => produtos ?? (produtos = new ProdutoFacade(repository));

        IPedidoFacade IFacade.Pedidos => pedidos ?? (pedidos = new PedidoFacade(repository));

        ILoginFacade IFacade.Logins => logins ?? (logins = new LoginFacade(repository));

        IUnidadeDeMedidaFacade IFacade.UnidadesDeMedidas => unidadesDeMedidas ?? (unidadesDeMedidas = new UnidadeDeMedidaFacade(repository));

        void IFacade.Dispose()
        {
            repository.Dispose();
        }
        void IFacade.Roolback()
        {
            repository.RollBack();
        }
        void IFacade.SaveChanges()
        {
            repository.SaveChanges();
        }
    }
}
