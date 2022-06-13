using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class AlunoRepository : AbstractRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(MyContext context) : base(context)
        {
        }
    }
}
