using System.Collections.Generic;

namespace MyAngular20.ApplicationService
{
    public class PaginadorDeListas<T> where T : class
    {
        private PaginadorDeListas() { }
        public PaginadorDeListas(List<T> lista, int totalRegistros)
        {
            Lista = lista;
            TotalRegistros = totalRegistros;
        }
        public List<T> Lista { get; }
        public int TotalRegistros { get; }

    }
}
