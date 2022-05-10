using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class CategoriaRepository : AbstractRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(MyContext context) : base(context)
        {

        }

        bool ICategoriaRepository.NomeConferenciaExiste(Categoria categoria)
        {
            return Context.Categorias.Any(p => p.NomeConferencia == categoria.NomeConferencia && p.Id != categoria.Id);
        }
    }
}
