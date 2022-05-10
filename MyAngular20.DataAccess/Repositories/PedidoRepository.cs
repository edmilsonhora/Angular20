using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class PedidoRepository : AbstractRepository<Pedido>, IPedidoRepository
    {


        public PedidoRepository(MyContext context) : base(context)
        {

        }
    }
}
