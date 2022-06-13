using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class NotaAdapter
    {
        public static List<NotaView> ConvertToView(this List<Nota> lista)
        {
            var novaLista = new List<NotaView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static NotaView ConvertToView(this Nota item)
        {
            if (item == null) return new NotaView();

            return new NotaView()
            {
                Id = item.Id,
                AlunoId = item.AlunoId,
                BimestreId = item.BimestreId,
                MateriaId = item.MateriaId,
                Valor = item.Valor,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
