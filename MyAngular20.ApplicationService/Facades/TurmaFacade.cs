using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class TurmaFacade : ITurmaFacade
    {
        private readonly IRepository _repository;

        public TurmaFacade(IRepository repository)
        {
            this._repository = repository;
        }
        void IViewFacade<TurmaView>.Excluir(int id)
        {
            var obj = _repository.Turmas.ObterPor(id);
            _repository.Turmas.Excluir(obj);
        }

        PaginadorDeListas<TurmaView> IViewFacade<TurmaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Turmas.TotalDeRegistros();
            var lista = _repository.Turmas.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<TurmaView>(lista, totalRegistros);
        }

        TurmaView IViewFacade<TurmaView>.ObterPor(int id)
        {
            return _repository.Turmas.ObterPor(id).ConvertToView();
        }

        List<TurmaView> IViewFacade<TurmaView>.ObterTodos()
        {
            return _repository.Turmas.ObterTodos().ConvertToView();
        }

        void IViewFacade<TurmaView>.Salvar(TurmaView view)
        {
            var obj = view.Id == 0 ? new Turma() : _repository.Turmas.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Curso = _repository.Cursos.ObterPor(view.CursoId);
            obj.Limite = view.Limite;
            obj.Ano = view.Ano;
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.RegistraAlteracao();
            obj.Validar();

            _repository.Turmas.Salvar(obj);
        }
    }
}
