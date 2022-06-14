using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.CommonPlace;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class CategoriaFacade : ICategoriaFacade
    {
        private readonly IRepository _repository;

        public CategoriaFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<CategoriaView>.Excluir(int id)
        {
            var obj = _repository.Categorias.ObterPor(id);           
            _repository.Categorias.Excluir(obj);
        }

        CategoriaView IViewFacade<CategoriaView>.ObterPor(int id)
        {
            return _repository.Categorias.ObterPor(id).ConvertToView();
        }

        PaginadorDeListas<CategoriaView> IViewFacade<CategoriaView>.ObterPaginado(int pageIndex, int pageSize)
        {

            int totalRegistros = _repository.Categorias.TotalDeRegistros();
            var lista = _repository.Categorias.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<CategoriaView>(lista, totalRegistros);

        }

        List<CategoriaView> IViewFacade<CategoriaView>.ObterTodos()
        {
            return _repository.Categorias.ObterTodos().ConvertToView();
        }

        void IViewFacade<CategoriaView>.Salvar(CategoriaView view)
        {
            var obj = view.Id == 0 ? new Categoria() : _repository.Categorias.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.NomeConferencia = Helper.GetConference(view.Nome);
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.Repository = _repository.Categorias;
            obj.RegistraAlteracao();

            obj.Validar();

            _repository.Categorias.Salvar(obj);
        }
    }
}
