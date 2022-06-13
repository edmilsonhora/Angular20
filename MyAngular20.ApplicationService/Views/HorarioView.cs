namespace MyAngular20.ApplicationService.Views
{
    public class HorarioView:ViewBase
    {
        public string DiaDaSemana { get; set; }
        public string Periodo { get; set; }
    }

    public interface IHorarioFacade : IViewFacade<HorarioView> { }
}
