﻿using System.Collections.Generic;

namespace MyAngular20.ApplicationService.Views
{

    public abstract class ViewBase
    {
        public int Id { get; set; }
    }

    public interface IViewFacade<T> where T : ViewBase
    {
        void Salvar(T view);
        void Excluir(int id);
        List<T> ObterTodos();
        PaginadorDeListas<T> ObterPaginado(int pageIndex, int pageSize);
        T ObterPor(int id);


    }

}
