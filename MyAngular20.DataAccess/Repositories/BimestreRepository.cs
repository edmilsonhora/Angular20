using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class BimestreRepository : AbstractRepository<Bimestre>, IBimestreRepository
    {
        public BimestreRepository(MyContext context) : base(context)
        {
        }
    }
}
