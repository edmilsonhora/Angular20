using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class HorarioFacade : IHorarioFacade
    {
        private readonly IRepository _repository;

        public HorarioFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<HorarioView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<HorarioView> IViewFacade<HorarioView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        HorarioView IViewFacade<HorarioView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<HorarioView> IViewFacade<HorarioView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<HorarioView>.Salvar(HorarioView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
