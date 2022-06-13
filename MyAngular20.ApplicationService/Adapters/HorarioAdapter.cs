using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class HorarioAdapter
    {
        public static List<HorarioView> ConvertToView(this List<Horario> lista)
        {
            var novaLista = new List<HorarioView>();

            foreach (var item in lista)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static HorarioView ConvertToView(this Horario item)
        {
            if (item == null) return new HorarioView();

            return new HorarioView()
            {
                Id = item.Id,
                Periodo = item.Periodo,
                DiaDaSemana = item.DiaDaSemana,
                CadastradoPor = item.CadastradoPor,
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",
                DataCadastro = item.DataCadastro.ToShortDateString()
            };

        }
    }
}
