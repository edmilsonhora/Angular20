using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
