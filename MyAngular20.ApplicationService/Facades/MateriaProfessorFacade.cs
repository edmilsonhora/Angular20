using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class MateriaProfessorFacade : IMateriaProfessorFacade
    {
        private readonly IRepository _repository;

        public MateriaProfessorFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<MateriaProfessorView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<MateriaProfessorView> IViewFacade<MateriaProfessorView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        MateriaProfessorView IViewFacade<MateriaProfessorView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<MateriaProfessorView> IViewFacade<MateriaProfessorView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<MateriaProfessorView>.Salvar(MateriaProfessorView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
