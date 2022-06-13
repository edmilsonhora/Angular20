namespace MyAngular20.ApplicationService.Views
{
    public class CategoriaView : ViewBase
    {
        public string Nome { get; set; }
        
    }

    public interface ICategoriaFacade : IViewFacade<CategoriaView>
    {

    }

}
