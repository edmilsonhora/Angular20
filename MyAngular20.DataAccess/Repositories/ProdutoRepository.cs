using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ProdutoRepository : AbstractRepository<Produto>, IProdutoRepository
    {
        private readonly MyContext context;

        public ProdutoRepository(MyContext context):base(context)
        {
            this.context = context;
        }

        bool IProdutoRepository.CodigoJahExiste(Produto produto)
        {
            return context.Produtos.Any(p => p.Codigo.Equals(produto.Codigo) && p.Id != produto.Id);
        }

        bool IProdutoRepository.NomeConferenciaExiste(Produto produto)
        {
            return context.Produtos.Any(p => p.DescricaoConferencia.Equals(produto.DescricaoConferencia) && p.Id != produto.Id);
        }
    }
}
