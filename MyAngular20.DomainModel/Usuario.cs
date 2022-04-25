using MyAngular20.CommonPlace;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DomainModel
{
    public class Usuario : EntityBase
    {
        public string NomeCompleto { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioNomeConferencia { get; set; }
        public string Senha { get; set; }
        [NotMapped]
        public string ConfirmaSenha { get; set; }
        public string Perfil { get; set; }
        public DateTime DataUltimoLogin { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public IUsuarioRepository Repository { get; set; }
        public void AutenticarPor(string senha)
        {
            if(Id == 0)
                throw new ApplicationException("Usuário não existe!");

            if (this.Senha != HelperRijndaelCrypto.Encrypt(senha, GlobalConst.ChaveCriptografia))
                throw new ApplicationException("Usuário ou Senha Incorreto!");

            if(!Ativo)
                throw new ApplicationException("Usuário Inativo!");
        }

        public override void Validar()
        {
            CampoTextoObrigatorio("Nome Completo", NomeCompleto);
            CampoTextoObrigatorio("Usuário Nome", UsuarioNome);
            CampoTextoObrigatorio("Email", Email);
            EmailEhObrigatorioEmFormatoValido(new ValidaEmail(Email));
            CampoTextoObrigatorio(nameof(Senha), Senha);
            CampoTextoObrigatorio(nameof(Perfil), Perfil);
            CampoJahDefinido(Repository.NomeConferenciaExiste(this), "Nome Usuário", UsuarioNome);

            if (this.Id.Equals(0))
            {
                if (Senha != ConfirmaSenha)
                    RegrasQuebradas.Append($"Senha não confere!{Environment.NewLine}");
                else
                    Senha = HelperRijndaelCrypto.Encrypt(Senha, GlobalConst.ChaveCriptografia);
            }

            base.Validar();
        }

        public void RegistraUltimoLogin()
        {
            if (Id == 0)
                throw new ApplicationException("Usuário não existe!");

            DataUltimoLogin = DateTime.Now;
        }
    }

    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ObterPor(string usuario);
        bool NomeConferenciaExiste(Usuario usuario);
    }
}
