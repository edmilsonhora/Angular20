using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class MateriaCursoRepository : AbstractRepository<MateriaCurso>, IMateriaCursoRepository
    {
        public MateriaCursoRepository(MyContext context) : base(context)
        {
        }
    }
}
