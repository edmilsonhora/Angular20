using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class MateriaFacade : IMateriaFacade
    {
        private readonly IRepository _repository;

        public MateriaFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<MateriaView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<MateriaView> IViewFacade<MateriaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        MateriaView IViewFacade<MateriaView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<MateriaView> IViewFacade<MateriaView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<MateriaView>.Salvar(MateriaView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
