using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Repositories
{
    internal class MateriaProfessorRepository : AbstractRepository<MateriaProfessor>, IMateriaProfessorRepository
    {
        public MateriaProfessorRepository(MyContext context) : base(context)
        {
        }
    }
}
