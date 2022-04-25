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
    internal class ClienteRepository : AbstractRepository<Cliente>, IClienteRepository
    {
        private readonly MyContext context;

        public ClienteRepository(MyContext context):base(context)
        {
            this.context = context;
        }

        List<Cliente> IClienteRepository.ObterPor(string nome)
        {
            return this.context.Clientes.Where(p => p.Nome.StartsWith(nome)).AsNoTracking().ToList();
        }
    }
}
