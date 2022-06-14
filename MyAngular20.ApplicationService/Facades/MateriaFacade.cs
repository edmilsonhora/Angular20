using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.CommonPlace;
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
            var obj = _repository.Materias.ObterPor(id);
            _repository.Materias.Excluir(obj);
        }

        PaginadorDeListas<MateriaView> IViewFacade<MateriaView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Materias.TotalDeRegistros();
            var lista = _repository.Materias.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<MateriaView>(lista, totalRegistros);
        }

        MateriaView IViewFacade<MateriaView>.ObterPor(int id)
        {
            return _repository.Materias.ObterPor(id).ConvertToView();
        }

        List<MateriaView> IViewFacade<MateriaView>.ObterTodos()
        {
            return _repository.Materias.ObterTodos().ConvertToView();
        }

        void IViewFacade<MateriaView>.Salvar(MateriaView view)
        {
            var obj = view.Id == 0 ? new Materia() : _repository.Materias.ObterPor(view.Id);
            obj.Nome = view.Nome;
            obj.NomeConferencia = Helper.GetConference(view.Nome);
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.Repository = _repository.Materias
;            obj.RegistraAlteracao();
            obj.Validar();

            _repository.Materias.Salvar(obj);
        }
    }
}
