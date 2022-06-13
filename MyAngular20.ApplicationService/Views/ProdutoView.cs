using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Views
{
    public class ProdutoView : ViewBase
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Ativo { get; set; }
        public string UnidadeDeMedida { get; set; }
        public string CategoriaNome { get; set; }
        public int CategoriaId { get; set; }
        public int UnidadeDeMedidaId { get; set; }
        public decimal QtdEmEstoque { get; set; }

    }

    public interface IProdutoFacade : IViewFacade<ProdutoView>
    {
        void Salvar(ProdutoView view, List<ProdutoFotoView> listaFotos);
    }
}
