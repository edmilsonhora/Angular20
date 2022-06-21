using Microsoft.EntityFrameworkCore;
using MyAngular20.CommonPlace;
using MyAngular20.DataAccess.Contexts;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace MyAngular20.DataAccess.Repositories
{
    internal class MateriaRepository : AbstractRepository<Materia>, IMateriaRepository
    {
        public MateriaRepository(MyContext context) : base(context)
        {
        }



        bool IMateriaRepository.NomeConferenciaExiste(Materia materia)
        {
            return Context.Materias.Any(p => p.NomeConferencia.Equals(materia.NomeConferencia) && p.Id != materia.Id);
        }
        List<Materia> IRepositoryBase<Materia>.ObterPaginado(FiltroPagina filtro)
        {
            var lista = Context.Materias
                .OrderByDescending(p => p.Id)
                .Skip((filtro.PageIndex) * filtro.PageSize)
                .Take(filtro.PageSize)
                .AsNoTracking()
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(filtro.Campo)  || string.IsNullOrWhiteSpace(filtro.Sort))
                return lista.ToList();

            var ordenacao = $"{filtro.Campo} {filtro.Sort}";
            return lista.OrderBy(ordenacao).ToList();
        }

        List<Materia> IMateriaRepository.ObterPor(int[] materiasIds)
        {
            return Context.Materias.Where(p => materiasIds.Contains(p.Id)).ToList();
        }


    }
}
