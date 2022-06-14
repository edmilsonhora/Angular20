using MyAngular20.ApplicationService.Adapters;
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
            var obj = _repository.Alunos.ObterPor(id);
            _repository.Alunos.Excluir(obj);
        }

        PaginadorDeListas<AlunoView> IViewFacade<AlunoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Alunos.TotalDeRegistros();
            var lista = _repository.Alunos.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<AlunoView>(lista, totalRegistros);
        }

        AlunoView IViewFacade<AlunoView>.ObterPor(int id)
        {
            return _repository.Alunos.ObterPor(id).ConvertToView();
        }

        List<AlunoView> IViewFacade<AlunoView>.ObterTodos()
        {
            return _repository.Alunos.ObterTodos().ConvertToView();
        }

        void IViewFacade<AlunoView>.Salvar(AlunoView view)
        {
            var obj = view.Id == 0 ? new Aluno() : _repository.Alunos.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Turma = _repository.Turmas.ObterPor(view.TurmaId);
            obj.AtualizadoPor = view.AtualizadoPor;            
            obj.RegistraAlteracao();
            obj.Validar();

            _repository.Alunos.Salvar(obj);
        }
    }
}
