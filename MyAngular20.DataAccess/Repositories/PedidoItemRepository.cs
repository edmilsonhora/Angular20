using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Repositories
{
    internal class PedidoItemRepository : AbstractRepository<PedidoItem>, IPedidoItemRepository
    {
        private readonly MyContext context;

        public PedidoItemRepository(MyContext context):base(context)
        {
            this.context = context;
        }
    }
}
