namespace MyAngular20.ApplicationService.Views
{
    public class LoginDataView
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public interface ILoginFacade
    {
        void Autenticar(LoginDataView view);

    }
}
