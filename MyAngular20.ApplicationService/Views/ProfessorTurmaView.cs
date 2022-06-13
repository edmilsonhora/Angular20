namespace MyAngular20.ApplicationService.Views
{
    public class ProfessorTurmaView : ViewBase
    {
        public string Professor { get; set; }
        public int ProfessorId { get; set; }
        public string Turma { get; set; }
        public int TurmaId { get; set; }
        public string Horario { get; set; }
        public int HorarioId { get; set; }
    }

    public interface IProfessorTurmaFacade : IViewFacade<ProfessorTurmaView> { }
}
