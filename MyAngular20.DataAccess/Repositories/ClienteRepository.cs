using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class ClienteRepository : AbstractRepository<Cliente>, IClienteRepository
    {

        public ClienteRepository(MyContext context) : base(context)
        {

        }

        List<Cliente> IClienteRepository.ObterPor(string nome)
        {
            return Context.Clientes.Where(p => p.Nome.StartsWith(nome)).AsNoTracking().ToList();
        }
    }
}
