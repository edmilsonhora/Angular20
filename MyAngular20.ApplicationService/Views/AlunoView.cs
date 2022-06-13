namespace MyAngular20.ApplicationService.Views
{
    public class AlunoView : ViewBase
    {
        public string Nome { get; set; }
        public int TurmaId { get; set; }
    }

    public interface IAlunoFacade : IViewFacade<AlunoView> { }
}
