using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class BimestreFacade : IBimestreFacade
    {
        private readonly IRepository _repository;

        public BimestreFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<BimestreView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<BimestreView> IViewFacade<BimestreView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        BimestreView IViewFacade<BimestreView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<BimestreView> IViewFacade<BimestreView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<BimestreView>.Salvar(BimestreView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
