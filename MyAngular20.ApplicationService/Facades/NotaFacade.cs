using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class NotaFacade : INotaFacade
    {
        private readonly IRepository _repository;

        public NotaFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<NotaView>.Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        PaginadorDeListas<NotaView> IViewFacade<NotaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        NotaView IViewFacade<NotaView>.ObterPor(int id)
        {
            throw new System.NotImplementedException();
        }

        List<NotaView> IViewFacade<NotaView>.ObterTodos()
        {
            throw new System.NotImplementedException();
        }

        void IViewFacade<NotaView>.Salvar(NotaView view)
        {
            throw new System.NotImplementedException();
        }
    }
}
