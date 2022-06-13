using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class TurmaFacade : ITurmaFacade
    {
        private readonly IRepository _repository;

        public TurmaFacade(IRepository repository)
        {
            this._repository = repository;
        }
        void IViewFacade<TurmaView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<TurmaView> IViewFacade<TurmaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        TurmaView IViewFacade<TurmaView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<TurmaView> IViewFacade<TurmaView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<TurmaView>.Salvar(TurmaView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
