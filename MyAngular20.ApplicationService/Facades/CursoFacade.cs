using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class CursoFacade : ICursoFacade
    {
        private readonly IRepository _repository;

        public CursoFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<CursoView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<CursoView> IViewFacade<CursoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        CursoView IViewFacade<CursoView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<CursoView> IViewFacade<CursoView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<CursoView>.Salvar(CursoView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
