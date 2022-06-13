namespace MyAngular20.ApplicationService.Views
{
    public class UsuarioView : ViewBase
    {
        public string NomeCompleto { get; set; }
        public string UsuarioNome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string AtivoStr { get; set; }
        public string Perfil { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public int Notificacoes { get; set; }
        public string DataUltimoLogin { get; set; }
      


    }

    public interface IUsuarioFacade : IViewFacade<UsuarioView>
    {
        UsuarioView ObterPor(string nomeUsuario);

    }
}
