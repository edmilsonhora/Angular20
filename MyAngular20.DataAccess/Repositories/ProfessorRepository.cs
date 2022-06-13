using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ProfessorRepository : AbstractRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(MyContext context) : base(context)
        {
        }
    }
}
