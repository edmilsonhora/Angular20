using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class MateriaRepository : AbstractRepository<Materia>, IMateriaRepository
    {
        public MateriaRepository(MyContext context) : base(context)
        {
        }
    }
}
