using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Repositories
{
    internal class UsuarioRepository : AbstractRepository<Usuario>, IUsuarioRepository
    {
        private readonly MyContext context;
        public UsuarioRepository(MyContext context):base(context)
        {
            this.context = context;
        }

        bool IUsuarioRepository.NomeConferenciaExiste(Usuario usuario)
        {
            return context.Usuarios.Any(p => p.UsuarioNomeConferencia.Equals(usuario.UsuarioNomeConferencia) && p.Id != usuario.Id);
        }

        Usuario IUsuarioRepository.ObterPor(string usuario)
        {
            Usuario user = context.Usuarios.FirstOrDefault(p => p.UsuarioNome == usuario);

            if (user == null)
                return new Usuario();

            return user;

            //return new Usuario()
            //{
            //    Id = 1,
            //    AtualizadoPor = "auto cadastro",
            //    CadastradoPor = "auto cadastro",
            //    DataAtualizacao = DateTime.Now.AddDays(-5),
            //    DataCadastro = DateTime.Now.AddDays(-7),
            //    DataUltimoLogin = DateTime.Now,                
            //    NomeCompleto = "Edmilson Silva da Hora",
            //    Perfil = "admin",
            //    Senha = "123456",
            //    UsuarioNome = "edmilson.hora"
            //};
        }
    }
}
