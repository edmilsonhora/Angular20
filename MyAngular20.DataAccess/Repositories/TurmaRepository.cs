using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class TurmaRepository : AbstractRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(MyContext context) : base(context)
        {
        }

        

        List<Turma> IRepositoryBase<Turma>.ObterPaginado(int pageIndex, int pageSize)
        {
            return Context.Turmas.Include(p => p.Curso)
                .OrderByDescending(p => p.Id)
                .Skip((pageIndex) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToList();
        }

        Turma IRepositoryBase<Turma>.ObterPor(int id)
        {
            return Context.Turmas.Include(p => p.Curso).FirstOrDefault(p => p.Id.Equals(id));
        }

        List<Turma> IRepositoryBase<Turma>.ObterTodos()
        {
            return Context.Turmas.Include(p => p.Curso).AsNoTracking().ToList();
        }
        
    }
}
