using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MyAngular20.DataAccess.Repositories
{
    internal class MateriaRepository : AbstractRepository<Materia>, IMateriaRepository
    {
        public MateriaRepository(MyContext context) : base(context)
        {
        }

        public bool NomeConferenciaExiste(Materia materia)
        {
            return Context.Materias.Any(p => p.NomeConferencia.Equals(materia.NomeConferencia) && p.Id != materia.Id);
        }

        List<Materia> IMateriaRepository.ObterPor(int[] materiasIds)
        {
            return Context.Materias.Where(p => materiasIds.Contains(p.Id)).AsNoTracking().ToList();
        }
    }
}
