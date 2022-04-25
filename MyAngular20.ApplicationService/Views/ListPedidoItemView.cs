using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
   public class ListPedidoItemView : List<PedidoItemView>
    {

        public ListPedidoItemView AddProdutosView(List<ProdutoView> produtosView)
        {

            foreach (var item in produtosView)
            {
                var obj = new PedidoItemView();
                obj.Descricao = item.Descricao;
                
            }

            return this;

        }

    }
}
