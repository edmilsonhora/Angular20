using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class UnidadeDeMedidaRepository : AbstractRepository<UnidadeDeMedida>, IUnidadeDeMedidaRepository
    {


        public UnidadeDeMedidaRepository(MyContext context) : base(context)
        {

        }
    }
}
