using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class MateriaCursoFacade : IMateriaCursoFacade
    {
        private readonly IRepository _repository;

        public MateriaCursoFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<MateriaCursoView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<MateriaCursoView> IViewFacade<MateriaCursoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        MateriaCursoView IViewFacade<MateriaCursoView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<MateriaCursoView> IViewFacade<MateriaCursoView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<MateriaCursoView>.Salvar(MateriaCursoView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
