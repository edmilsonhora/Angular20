using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
    public class PedidoItemView:ViewBase
    {

        public string Descricao { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }        
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
    }

    public interface PedidoItemFacade:IViewFacade<PedidoItemView>
    {

    }
}
