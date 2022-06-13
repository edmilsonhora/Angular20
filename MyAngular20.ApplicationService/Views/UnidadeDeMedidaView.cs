namespace MyAngular20.ApplicationService.Views
{
    public class UnidadeDeMedidaView : ViewBase
    {
        public string Nome { get; set; }
        public string Simbolo { get; set; }

    }

    public interface IUnidadeDeMedidaFacade : IViewFacade<UnidadeDeMedidaView>
    {

    }
}
