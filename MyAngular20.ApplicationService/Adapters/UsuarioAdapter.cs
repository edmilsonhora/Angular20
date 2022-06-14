using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Adapters
{
    internal static class UsuarioAdapter
    {
        public static List<UsuarioView> ConvertToView(this List<Usuario> list)
        {
            var novaLista = new List<UsuarioView>();

            foreach (var item in list)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static UsuarioView ConvertToView(this Usuario item)
        {
            if (item == null || item.Id.Equals(0)) return new UsuarioView();

            return new UsuarioView()
            {
                Id = item.Id,
                NomeCompleto = item.NomeCompleto,
                UsuarioNome = item.UsuarioNome,
                Ativo = item.Ativo,
                Email = item.Email,
                DataUltimoLogin = item.DataUltimoLogin.ToString(),
                Notificacoes = item.Perfil == "admin" ? 0 : 4,
                AtivoStr = item.Ativo ? "Ativo" : "Inativo",
                Perfil = item.Perfil,
                CadastradoPor = item.CadastradoPor,
                DataCadastro = item.DataCadastro.ToShortDateString(),
                AtualizadoPor = item.AtualizadoPor,
                DataAtualizacao = $"{item.DataAtualizacao.ToShortDateString()} às {item.DataAtualizacao.ToShortTimeString()}",


            };

        }
    }
}
