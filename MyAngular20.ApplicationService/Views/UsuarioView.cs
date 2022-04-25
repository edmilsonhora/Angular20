using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
    public class UsuarioView:ViewBase
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
        public string DataCadastro { get; set; }
        public string CadastradoPor { get; set; }
        public string DataAtualizacao { get; set; }
        public string AtualizadoPor { get; set; }


    }

    public interface IUsuarioFacade:IViewFacade<UsuarioView>
    {        
        UsuarioView ObterPor(string nomeUsuario);
       
    }
}
