using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Views
{
    public class ClienteView : ViewBase
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        
    }

    public interface IClienteFacade : IViewFacade<ClienteView>
    {
        List<ClienteView> ObterPor(string nome);
    }
}
