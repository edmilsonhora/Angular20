using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class CursoAdapter
    {
        public static List<CursoView> ConvertToView(this List<Curso> lista)
        {
            var novaLista = new List<CursoView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static CursoView ConvertToView(this Curso item)
        {
            if (item == null) return new CursoView();

            return new CursoView()
            {
                Id = item.Id,
                Nome = item.Nome,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
