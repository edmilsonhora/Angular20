using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Views
{
    public class ClienteView : ViewBase
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CadastradoPor { get; set; }
        public string DataCadastro { get; set; }
        public string AtualizadoPor { get; set; }
        public string DataAtualizacao { get; set; }
    }

    public interface IClienteFacade : IViewFacade<ClienteView>
    {
        List<ClienteView> ObterPor(string nome);
    }
}
