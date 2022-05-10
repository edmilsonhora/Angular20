namespace MyAngular20.ApplicationService.Views
{
    public class CategoriaView : ViewBase
    {
        public string Nome { get; set; }
        public string CadastradoPor { get; set; }
        public string DataCadastro { get; set; }
        public string AtualizadoPor { get; set; }
        public string DataAtualizacao { get; set; }
    }

    public interface ICategoriaFacade : IViewFacade<CategoriaView>
    {

    }

}
