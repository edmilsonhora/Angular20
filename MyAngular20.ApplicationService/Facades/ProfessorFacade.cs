using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Facades
{
    internal class ProfessorFacade : IProfessorFacade
    {
        private readonly IRepository _repository;

        public ProfessorFacade(IRepository repository)
        {
            this._repository = repository;
        }

        void IViewFacade<ProfessorView>.Excluir(int id)
        {
            var obj = _repository.Professores.ObterPor(id);
            obj.Materias.Clear();
            _repository.Professores.Excluir(obj);
        }

        PaginadorDeListas<ProfessorView> IViewFacade<ProfessorView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Professores.TotalDeRegistros();
            var lista = _repository.Professores.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<ProfessorView>(lista, totalRegistros);
        }

        ProfessorView IViewFacade<ProfessorView>.ObterPor(int id)
        {
            return _repository.Professores.ObterPor(id).ConvertToView();
        }

        List<ProfessorView> IViewFacade<ProfessorView>.ObterTodos()
        {
            return _repository.Professores.ObterTodos().ConvertToView();
        }

        void IViewFacade<ProfessorView>.Salvar(ProfessorView view)
        {
            var obj = view.Id == 0 ? new Professor() : _repository.Professores.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.Materias?.Clear();
            obj.Materias = _repository.Materias.ObterPor(view.MateriasIds);
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.RegistraAlteracao();
            obj.Validar();

            _repository.Professores.Salvar(obj);
        }
       
    }
}
