using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal abstract class AbstractRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
       
        public MyContext Context { get; set; }

        public AbstractRepository(MyContext context)
        {
            Context = context;
        }

        void IRepositoryBase<T>.Excluir(T entity)
        {
            if (entity == null) return;
            Context.Set<T>().Remove(entity);
        }

        List<T> IRepositoryBase<T>.ObterPaginado(int pageIndex, int pageSize)
        {
            return Context.Set<T>()
                .OrderByDescending(p => p.Id)
                .Skip((pageIndex) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToList();
        }

        T IRepositoryBase<T>.ObterPor(int id)
        {
            return Context.Set<T>().FirstOrDefault(p => p.Id.Equals(id));
        }

        List<T> IRepositoryBase<T>.ObterTodos()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        void IRepositoryBase<T>.Salvar(T entity)
        {
            if (entity.Id.Equals(0))
                Context.Set<T>().Add(entity);
        }

        int IRepositoryBase<T>.TotalDeRegistros()
        {
            return Context.Set<T>().AsNoTracking().Count();
        }
    }
}
