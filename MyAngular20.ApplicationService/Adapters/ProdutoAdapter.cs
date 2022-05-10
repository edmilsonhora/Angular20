using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class ProdutoAdapter
    {
        public static List<ProdutoView> ConvertToView(this List<Produto> lista)
        {
            List<ProdutoView> novaLista = new List<ProdutoView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static ProdutoView ConvertToView(this Produto item)
        {
            if (item == null) return new ProdutoView();

            return new ProdutoView()
            {
                Id = item.Id,
                Descricao = item.Descricao,
                Ativo = item.Ativo,
                CategoriaId = item.CategoriaId,
                Codigo = item.Codigo,
                PrecoUnitario = item.PrecoUnitario,
                QtdEmEstoque = item.QtdEmEstoque,
                UnidadeDeMedidaId = item.UnidadeDeMedidaId,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()

            };

        }
    }
}
