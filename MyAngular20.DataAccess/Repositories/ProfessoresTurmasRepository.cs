using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ProfessoresTurmasRepository : AbstractRepository<ProfessoresTurmas>, IProfessoresTurmasRepository
    {
        public ProfessoresTurmasRepository(MyContext context) : base(context)
        {
        }
    }
}
