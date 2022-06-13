namespace MyAngular20.ApplicationService.Views
{
    public class TurmaView:ViewBase
    {
        public string Nome { get; set; }       
        public int CursoId { get; set; }
    }

    public interface ITurmaFacade : IViewFacade<TurmaView> { }
}
