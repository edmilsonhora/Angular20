using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Repositories
{
    internal class CategoriaRepository : AbstractRepository<Categoria>, ICategoriaRepository
    {
        private readonly MyContext context;

        public CategoriaRepository(MyContext context):base(context)
        {
            this.context = context;
        }

        bool ICategoriaRepository.NomeConferenciaExiste(Categoria categoria)
        {
            return this.context.Categorias.Any(p => p.NomeConferencia == categoria.NomeConferencia && p.Id != categoria.Id);
        }
    }
}
