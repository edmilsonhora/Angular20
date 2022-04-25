using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
