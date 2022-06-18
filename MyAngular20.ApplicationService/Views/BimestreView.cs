namespace MyAngular20.ApplicationService.Views
{
    public class BimestreView : ViewBase
    {
        public string Nome { get; set; }
        public string Ano { get; set; }
    }

    public interface IBimestreFacade : IViewFacade<BimestreView> { }
}
