using MyAngular20.DataAccess.Contexts;
using MyAngular20.DataAccess.Repositories;
using MyAngular20.DomainModel;
using System;

namespace MyAngular20.DataAccess
{
    public class Repository : IRepository, IDisposable
    {
        private IClienteRepository clientes;
        private IProdutoRepository produtos;
        private IPedidoItemRepository pedidosItens;
        private ICategoriaRepository categorias;
        private IUsuarioRepository usuarios;
        private IPedidoRepository pedidos;
        private IUnidadeDeMedidaRepository unidadesDeMedidas;
        private readonly MyContext context;

        public Repository(string conn = "")
        {
            this.context = new MyContext(conn);
        }

        IClienteRepository IRepository.Clientes => clientes ?? (clientes = new ClienteRepository(context));

        ICategoriaRepository IRepository.Categorias => categorias ?? (categorias = new CategoriaRepository(context));

        IPedidoRepository IRepository.Pedidos => pedidos ?? (pedidos = new PedidoRepository(context));

        IProdutoRepository IRepository.Produtos => produtos ?? (produtos = new ProdutoRepository(context));

        IPedidoItemRepository IRepository.PedidosItens => pedidosItens ?? (pedidosItens = new PedidoItemRepository(context));

        IUsuarioRepository IRepository.Usuarios => usuarios ?? (usuarios = new UsuarioRepository(context));

        IUnidadeDeMedidaRepository IRepository.UnidadesDeMedida => unidadesDeMedidas ?? (unidadesDeMedidas = new UnidadeDeMedidaRepository(context));

        public void Dispose()
        {

        }

        void IRepository.Dispose()
        {
            throw new NotImplementedException();
        }

        void IRepository.RollBack()
        {
            clientes = null;
            categorias = null;
            produtos = null;
            pedidos = null;
            pedidosItens = null;
            usuarios = null;
            unidadesDeMedidas = null;

        }

        void IRepository.SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
