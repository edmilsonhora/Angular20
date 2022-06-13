namespace MyAngular20.ApplicationService.Views
{
    public class NotaView : ViewBase
    {
        public double Valor { get; set; }
        public int MateriaId { get; set; }
        public int AlunoId { get; set; }
        public int BimestreId { get; set; }
        public string Materia { get; set; }
        public string Aluno { get; set; }
        public string Bimestre { get; set; }

    }

    public interface INotaFacade : IViewFacade<NotaView> { }
}
