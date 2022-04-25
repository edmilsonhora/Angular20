using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DomainModel
{
   public class ProdutoFoto : EntityBase
    {
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public byte[] Bytes { get; set; }
        public string NomeArquivo { get; set; }
        public string Extensao { get; set; }
        public long Tamanho { get; set; }
        public string MymeType { get; set; }
        public bool Principal { get; set; }
    }
}
