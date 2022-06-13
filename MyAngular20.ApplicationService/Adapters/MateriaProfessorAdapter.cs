using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class MateriaProfessorAdapter
    {
        public static List<MateriaProfessorView> ConvertToView(this List<MateriaProfessor> lista)
        {
            var novaLista = new List<MateriaProfessorView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static MateriaProfessorView ConvertToView(this MateriaProfessor item)
        {
            if (item == null) return new MateriaProfessorView();

            return new MateriaProfessorView()
            {
                Id = item.Id,
                MateriaId = item.MateriaId,
                ProfessorId = item.ProfessorId,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
