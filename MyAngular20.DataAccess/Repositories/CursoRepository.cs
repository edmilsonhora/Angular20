using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class CursoRepository : AbstractRepository<Curso>, ICursoRepository
    {
        public CursoRepository(MyContext context) : base(context)
        {
        }
    }
}
