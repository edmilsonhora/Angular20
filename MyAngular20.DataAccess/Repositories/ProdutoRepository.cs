using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ProdutoRepository : AbstractRepository<Produto>, IProdutoRepository
    {


        public ProdutoRepository(MyContext context) : base(context)
        {

        }

        bool IProdutoRepository.CodigoJahExiste(Produto produto)
        {
            return Context.Produtos.Any(p => p.Codigo.Equals(produto.Codigo) && p.Id != produto.Id);
        }

        bool IProdutoRepository.NomeConferenciaExiste(Produto produto)
        {
            return Context.Produtos.Any(p => p.DescricaoConferencia.Equals(produto.DescricaoConferencia) && p.Id != produto.Id);
        }
    }
}
