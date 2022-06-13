using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class NotaRepository : AbstractRepository<Nota>, INotaRepository
    {
        public NotaRepository(MyContext context) : base(context)
        {
        }
    }
}
