using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{

    internal static class TurmaAdapter
    {
        public static List<TurmaView> ConvertToView(this List<Turma> lista)
        {
            var novaLista = new List<TurmaView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static TurmaView ConvertToView(this Turma item)
        {
            if (item == null) return new TurmaView();

            return new TurmaView()
            {
                Id = item.Id,
                Nome = item.Nome,
                CursoId = item.CursoId,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
