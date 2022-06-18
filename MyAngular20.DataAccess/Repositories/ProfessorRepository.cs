using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ProfessorRepository : AbstractRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(MyContext context) : base(context)
        {
        }
               

        List<Professor> IRepositoryBase<Professor>.ObterPaginado(int pageIndex, int pageSize)
        {
            return Context.Professores.Include(p => p.Materias)
                .OrderByDescending(p => p.Id)
                .Skip((pageIndex) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToList();
        }

        Professor IRepositoryBase<Professor>.ObterPor(int id)
        {
            return Context.Professores.Include(p => p.Materias).FirstOrDefault(p => p.Id.Equals(id));
        }

        List<Professor> IRepositoryBase<Professor>.ObterTodos()
        {
            return Context.Professores.Include(p => p.Materias).AsNoTracking().ToList();
        }

       
    }
}
