using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class BimestreAdapter
    {
        public static List<BimestreView> ConvertToView(this List<Bimestre> lista)
        {
            var novaLista = new List<BimestreView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static BimestreView ConvertToView(this Bimestre item)
        {
            if (item == null) return new BimestreView();

            return new BimestreView()
            {
                Id = item.Id,
                Nome = item.Nome,
                Ano = item.Ano,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
