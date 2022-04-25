using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService
{
    public class Paginador
    {
        public int Pagina { get; set; }
        public int Tamanho { get; set; }
        public string Campo { get; set; }
        public bool OrdemReversa { get; set; }
        public int TotalRegistros { get; set; }

    }
}
