using MyAngular20.ApplicationService.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService
{
   public interface IFacade
    {
        void SaveChanges();
        void Roolback();
        void Dispose();
        public ICategoriaFacade Categorias { get; }
        public IClienteFacade Clientes { get; }
        public IUsuarioFacade Usuarios { get; }
        public IProdutoFacade Produtos { get; }
        public IPedidoFacade Pedidos { get; }
        public ILoginFacade Logins { get; }
        public IUnidadeDeMedidaFacade UnidadesDeMedidas { get;}
    }
}
