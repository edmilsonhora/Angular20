using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class ProfessorTurmaFacade : IProfessorTurmaFacade
    {
        private readonly IRepository _repository;

        public ProfessorTurmaFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<ProfessorTurmaView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<ProfessorTurmaView> IViewFacade<ProfessorTurmaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        ProfessorTurmaView IViewFacade<ProfessorTurmaView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<ProfessorTurmaView> IViewFacade<ProfessorTurmaView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<ProfessorTurmaView>.Salvar(ProfessorTurmaView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
