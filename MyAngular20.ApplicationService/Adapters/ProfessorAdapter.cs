using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class ProfessorAdapter
    {
        public static List<ProfessorView> ConvertToView(this List<Professor> lista)
        {
            var novaLista = new List<ProfessorView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static ProfessorView ConvertToView(this Professor item)
        {
            if (item == null) return new ProfessorView();

            return new ProfessorView()
            {
                Id = item.Id,
                Nome = item.Nome,
                MateriasIds = item.Materias.Select(p => p.Id).ToArray(),
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
