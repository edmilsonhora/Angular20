using System.Collections.Generic;

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
