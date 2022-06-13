namespace MyAngular20.ApplicationService.Views
{
    public class CursoView : ViewBase
    {
        public string Nome { get; set; }
    }

    public interface ICursoFacade : IViewFacade<CursoView> { }
}
