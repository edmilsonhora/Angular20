using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ProfessorTurmaRepository : AbstractRepository<ProfessorTurma>, IProfessorTurmaRepository
    {
        public ProfessorTurmaRepository(MyContext context) : base(context)
        {
        }
    }
}
