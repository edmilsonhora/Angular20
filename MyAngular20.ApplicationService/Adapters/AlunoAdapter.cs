using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class AlunoAdapter
    {
        public static List<AlunoView> ConvertToView(this List<Aluno> lista)
        {
            List<AlunoView> novaLista = new List<AlunoView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static AlunoView ConvertToView(this Aluno item)
        {
            if (item == null) return new AlunoView();

            return new AlunoView()
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
