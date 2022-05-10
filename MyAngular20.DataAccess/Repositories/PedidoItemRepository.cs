using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class PedidoItemRepository : AbstractRepository<PedidoItem>, IPedidoItemRepository
    {


        public PedidoItemRepository(MyContext context) : base(context)
        {

        }
    }
}
