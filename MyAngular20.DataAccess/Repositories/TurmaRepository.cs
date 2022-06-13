using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class TurmaRepository : AbstractRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(MyContext context) : base(context)
        {
        }
    }
}
