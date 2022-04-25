using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class UnidadeDeMedidaAdapter
    {

        public static List<UnidadeDeMedidaView> ConvertToView(this List<UnidadeDeMedida> lista)
        {
            List<UnidadeDeMedidaView> novaLista = new List<UnidadeDeMedidaView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static UnidadeDeMedidaView ConvertToView(this UnidadeDeMedida item)
        {
            if (item == null) return new UnidadeDeMedidaView();

            return new UnidadeDeMedidaView()
            {
                Id = item.Id,
                Nome = item.Nome,
                Simbolo = item.Simbolo,                
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()

            };

        }
    }
}
