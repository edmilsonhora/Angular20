using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class ProfessorTurmaAdapter
    {
        public static List<ProfessorTurmaView> ConvertToView(this List<ProfessorTurma> lista)
        {
            var novaLista = new List<ProfessorTurmaView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static ProfessorTurmaView ConvertToView(this ProfessorTurma item)
        {
            if (item == null) return new ProfessorTurmaView();

            return new ProfessorTurmaView()
            {
                Id = item.Id,
                HorarioId = item.HorarioId,
                ProfessorId = item.ProfessorId,
                TurmaId = item.TurmaId,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
