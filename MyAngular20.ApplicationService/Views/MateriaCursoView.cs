namespace MyAngular20.ApplicationService.Views
{
    public class MateriaCursoView:ViewBase
    {
        public string Materia { get; set; }
        public int MateriaId { get; set; }
        public string Curso { get; set; }
        public int CursoId { get; set; }
        public double CargaHoraria { get; set; }

    }

    public interface IMateriaCursoFacade : IViewFacade<MateriaCursoView> { }
}
