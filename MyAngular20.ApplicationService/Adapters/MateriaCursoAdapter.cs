using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class MateriaCursoAdapter
    {
        public static List<MateriaCursoView> ConvertToView(this List<MateriaCurso> lista)
        {
            var novaLista = new List<MateriaCursoView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static MateriaCursoView ConvertToView(this MateriaCurso item)
        {
            if (item == null) return new MateriaCursoView();

            return new MateriaCursoView()
            {
                Id = item.Id,
                MateriaId = item.MateriaId,
                CursoId = item.CursoId,
                CargaHoraria = item.CargaHoraria,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
