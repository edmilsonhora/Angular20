using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class BimestreFacade : IBimestreFacade
    {
        private readonly IRepository _repository;

        public BimestreFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<BimestreView>.Excluir(int id)
        {
            var obj = _repository.Bimestres.ObterPor(id);
            _repository.Bimestres.Excluir(obj);
        }

        PaginadorDeListas<BimestreView> IViewFacade<BimestreView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Bimestres.TotalDeRegistros();
            var lista = _repository.Bimestres.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<BimestreView>(lista, totalRegistros);
        }

        BimestreView IViewFacade<BimestreView>.ObterPor(int id)
        {
            return _repository.Bimestres.ObterPor(id).ConvertToView();
        }

        List<BimestreView> IViewFacade<BimestreView>.ObterTodos()
        {
            return _repository.Bimestres.ObterTodos().ConvertToView();
        }


        void IViewFacade<BimestreView>.Salvar(BimestreView view)
        {
            var obj = view.Id == 0 ? new Bimestre() : _repository.Bimestres.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Ano = view.Ano;
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.RegistraAlteracao();
            obj.Validar();

            _repository.Bimestres.Salvar(obj);

        }

    }
}
