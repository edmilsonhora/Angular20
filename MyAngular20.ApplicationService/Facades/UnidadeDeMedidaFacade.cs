using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    public class UnidadeDeMedidaFacade : IUnidadeDeMedidaFacade
    {
        private readonly IRepository _repository;

        public UnidadeDeMedidaFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<UnidadeDeMedidaView>.Excluir(int id)
        {
            var obj = _repository.UnidadesDeMedida.ObterPor(id);
            if (obj == null) return;
            _repository.UnidadesDeMedida.Excluir(obj);
        }

        PaginadorDeListas<UnidadeDeMedidaView> IViewFacade<UnidadeDeMedidaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.UnidadesDeMedida.TotalDeRegistros();
            var lista = _repository.UnidadesDeMedida.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<UnidadeDeMedidaView>(lista, totalRegistros);
        }

        UnidadeDeMedidaView IViewFacade<UnidadeDeMedidaView>.ObterPor(int id)
        {
            return _repository.UnidadesDeMedida.ObterPor(id).ConvertToView();
        }

        List<UnidadeDeMedidaView> IViewFacade<UnidadeDeMedidaView>.ObterTodos()
        {
            return _repository.UnidadesDeMedida.ObterTodos().ConvertToView();
        }

        void IViewFacade<UnidadeDeMedidaView>.Salvar(UnidadeDeMedidaView view)
        {
            var obj = view.Id == 0 ? new UnidadeDeMedida() : _repository.UnidadesDeMedida.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Simbolo = view.Simbolo;
            obj.AtualizadoPor = view.AtualizadoPor;

            obj.RegistraAlteracao();

            obj.Validar();

            _repository.UnidadesDeMedida.Salvar(obj);
        }
    }
}
