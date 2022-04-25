using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Repositories
{
    internal abstract class AbstractRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly MyContext _context;

        public AbstractRepository(MyContext context)
        {
            this._context = context;
        }

        void IRepositoryBase<T>.Excluir(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        List<T> IRepositoryBase<T>.ObterPaginado(int pageIndex, int pageSize)
        {
            return _context.Set<T>()
                .OrderByDescending(p => p.Id)
                .Skip((pageIndex) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToList();
        }

        T IRepositoryBase<T>.ObterPor(int id)
        {
            return _context.Set<T>().FirstOrDefault(p => p.Id.Equals(id));
        }

        List<T> IRepositoryBase<T>.ObterTodos()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        void IRepositoryBase<T>.Salvar(T entity)
        {
            if (entity.Id.Equals(0))
                _context.Set<T>().Add(entity);
        }

        int IRepositoryBase<T>.TotalDeRegistros()
        {
            return _context.Set<T>().AsNoTracking().Count();
        }
    }
}
