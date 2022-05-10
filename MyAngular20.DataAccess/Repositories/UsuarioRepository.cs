using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class UsuarioRepository : AbstractRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(MyContext context) : base(context)
        {

        }

        bool IUsuarioRepository.NomeConferenciaExiste(Usuario usuario)
        {
            return Context.Usuarios.Any(p => p.UsuarioNomeConferencia.Equals(usuario.UsuarioNomeConferencia) && p.Id != usuario.Id);
        }

        Usuario IUsuarioRepository.ObterPor(string usuario)
        {
            Usuario user = Context.Usuarios.FirstOrDefault(p => p.UsuarioNome == usuario);

            if (user == null)
                return new Usuario();

            return user;

        }
    }
}
