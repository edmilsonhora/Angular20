using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class AlunoFacade : IAlunoFacade
    {
        private readonly IRepository _repository;

        public AlunoFacade(IRepository repository)
        {
            this._repository = repository;
        }
        void IViewFacade<AlunoView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<AlunoView> IViewFacade<AlunoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        AlunoView IViewFacade<AlunoView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<AlunoView> IViewFacade<AlunoView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<AlunoView>.Salvar(AlunoView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
