namespace MyAngular20.ApplicationService.Views
{
    public class TurmaView : ViewBase
    {
        public string Nome { get; set; }
        public int CursoId { get; set; }
        public string Curso { get; set; }
        public short Limite { get; set; }
        public string QtdAtual { get; set; }
        public string Ano { get; set; }
    }

    public interface ITurmaFacade : IViewFacade<TurmaView> { }
}
