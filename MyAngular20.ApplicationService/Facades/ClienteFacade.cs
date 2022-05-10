using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class ClienteFacade : IClienteFacade
    {
        private readonly IRepository _repository;

        public ClienteFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<ClienteView>.Excluir(int id)
        {
            var obj = _repository.Clientes.ObterPor(id);
            if (obj == null) return;
            _repository.Clientes.Excluir(obj);
        }

        ClienteView IViewFacade<ClienteView>.ObterPor(int id)
        {
            return _repository.Clientes.ObterPor(id).ConvertToView();
        }

        PaginadorDeListas<ClienteView> IViewFacade<ClienteView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Clientes.TotalDeRegistros();
            var lista = _repository.Clientes.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<ClienteView>(lista, totalRegistros);
        }

        List<ClienteView> IViewFacade<ClienteView>.ObterTodos()
        {
            return _repository.Clientes.ObterTodos().ConvertToView();
        }

        void IViewFacade<ClienteView>.Salvar(ClienteView view)
        {
            var obj = view.Id == 0 ? new Cliente() : _repository.Clientes.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Email = view.Email;
            obj.Telefone = view.Telefone;
            obj.AtualizadoPor = view.AtualizadoPor;

            obj.RegistraAlteracao();

            obj.Validar();

            _repository.Clientes.Salvar(obj);
        }

        List<ClienteView> IClienteFacade.ObterPor(string nome)
        {
            return _repository.Clientes.ObterPor(nome).ConvertToView();
        }
    }
}
