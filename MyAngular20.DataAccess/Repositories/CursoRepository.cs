using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class CursoRepository : AbstractRepository<Curso>, ICursoRepository
    {
        public CursoRepository(MyContext context) : base(context)
        {
        }

        bool ICursoRepository.NomeConferenciaExiste(Curso curso)
        {
            return Context.Cursos.Any(p => p.NomeConferencia.Equals(curso.NomeConferencia) && p.Id != curso.Id);
        }
    }
}
