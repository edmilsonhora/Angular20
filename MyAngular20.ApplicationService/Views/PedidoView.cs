using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
    public class PedidoView:ViewBase
    {
       
        public DateTime Data { get; set; }
        public string ClienteNome { get; set; }
        public int ClienteId { get; set; }
        public List<PedidoItemView> Itens { get; set; }
        public decimal TotalDoPedido { get; set; }
    }

    public interface IPedidoFacade:IViewFacade<PedidoView>
    {
       
    }
}
