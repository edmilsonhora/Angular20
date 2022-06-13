using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class ProfessorFacade : IProfessorFacade
    {
        private readonly IRepository _repository;

        public ProfessorFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<ProfessorView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<ProfessorView> IViewFacade<ProfessorView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        ProfessorView IViewFacade<ProfessorView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<ProfessorView> IViewFacade<ProfessorView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<ProfessorView>.Salvar(ProfessorView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
