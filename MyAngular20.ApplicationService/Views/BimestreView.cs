namespace MyAngular20.ApplicationService.Views
{
    public class BimestreView : ViewBase
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
    }

    public interface IBimestreFacade : IViewFacade<BimestreView> { }
}
