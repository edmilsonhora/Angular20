using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class PedidoFacade : IPedidoFacade
    {
        private readonly IRepository _repository;

        public PedidoFacade(IRepository repository)
        {
            this._repository = repository;
        }
        void IViewFacade<PedidoView>.Excluir(int id)
        {
            throw new NotImplementedException();
        }

        PedidoView IViewFacade<PedidoView>.ObterPor(int id)
        {
            throw new NotImplementedException();
        }

        PaginadorDeListas<PedidoView> IViewFacade<PedidoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        List<PedidoView> IViewFacade<PedidoView>.ObterTodos()
        {
            throw new NotImplementedException();
        }

        void IViewFacade<PedidoView>.Salvar(PedidoView view)
        {
            throw new NotImplementedException();
        }
    }
}
