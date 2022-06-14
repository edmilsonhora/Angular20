using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.CommonPlace;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class CursoFacade : ICursoFacade
    {
        private readonly IRepository _repository;

        public CursoFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<CursoView>.Excluir(int id)
        {
            var obj = _repository.Cursos.ObterPor(id);
            _repository.Cursos.Excluir(obj);
        }

        PaginadorDeListas<CursoView> IViewFacade<CursoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Cursos.TotalDeRegistros();
            var lista = _repository.Cursos.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<CursoView>(lista, totalRegistros);
        }

        CursoView IViewFacade<CursoView>.ObterPor(int id)
        {
            return _repository.Cursos.ObterPor(id).ConvertToView();
        }

        List<CursoView> IViewFacade<CursoView>.ObterTodos()
        {
            return _repository.Cursos.ObterTodos().ConvertToView();
        }

        void IViewFacade<CursoView>.Salvar(CursoView view)
        {
            var obj = view.Id == 0 ? new Curso() : _repository.Cursos.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.NomeConferencia = Helper.GetConference(view.Nome);
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.Repository = _repository.Cursos;
            obj.RegistraAlteracao();
            obj.Validar();

            _repository.Cursos.Salvar(obj);
        }
    }
}
