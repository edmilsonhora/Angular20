using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Repositories
{
    internal class HorarioRepository : AbstractRepository<Horario>, IHorarioRepository
    {
        public HorarioRepository(MyContext context) : base(context)
        {
        }
    }
}
