using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class CategoriaAdapter
    {

        public static List<CategoriaView> ConvertToView(this List<Categoria> lista)
        {
            List<CategoriaView> novaLista = new List<CategoriaView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static CategoriaView ConvertToView(this Categoria item)
        {
            if (item == null) return new CategoriaView();

            return new CategoriaView()
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
