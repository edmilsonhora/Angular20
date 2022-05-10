using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.CommonPlace;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class UsuarioFacade : IUsuarioFacade
    {
        private readonly IRepository _repository;

        public UsuarioFacade(IRepository repository)
        {
            this._repository = repository;
        }
        void IViewFacade<UsuarioView>.Excluir(int id)
        {
            var obj = _repository.Usuarios.ObterPor(id);
            if (obj == null) return;
            _repository.Usuarios.Excluir(obj);
        }

        UsuarioView IViewFacade<UsuarioView>.ObterPor(int id)
        {
            return _repository.Usuarios.ObterPor(id).ConvertToView();
        }

        PaginadorDeListas<UsuarioView> IViewFacade<UsuarioView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Usuarios.TotalDeRegistros();
            var lista = _repository.Usuarios.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<UsuarioView>(lista, totalRegistros);
        }

        UsuarioView IUsuarioFacade.ObterPor(string nomeUsuario)
        {
            var u = _repository.Usuarios.ObterPor(nomeUsuario);
            u.RegistraUltimoLogin();
            return u.ConvertToView();

        }

        List<UsuarioView> IViewFacade<UsuarioView>.ObterTodos()
        {
            return _repository.Usuarios.ObterTodos().ConvertToView();
        }

        void IViewFacade<UsuarioView>.Salvar(UsuarioView view)
        {
            var obj = view.Id == 0 ? new Usuario() : _repository.Usuarios.ObterPor(view.Id);
            obj.NomeCompleto = view.NomeCompleto;
            obj.UsuarioNome = view.UsuarioNome;
            obj.UsuarioNomeConferencia = Helper.GetConference(view.UsuarioNome);
            obj.Ativo = view.Ativo;
            obj.Email = view.Email;
            obj.Perfil = view.Perfil;

            if (view.Id == 0)
            {
                obj.Senha = view.Senha;
                obj.ConfirmaSenha = view.ConfirmaSenha;
                obj.DataUltimoLogin = DateTime.Now;
            }


            obj.AtualizadoPor = view.AtualizadoPor;
            obj.Repository = _repository.Usuarios;
            obj.RegistraAlteracao();

            obj.Validar();

            _repository.Usuarios.Salvar(obj);
        }
    }
}
