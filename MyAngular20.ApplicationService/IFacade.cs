using MyAngular20.ApplicationService.Views;

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
        public IUnidadeDeMedidaFacade UnidadesDeMedidas { get; }
    }
}
