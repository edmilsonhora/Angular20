using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
   public class ProdutoFotoView: ViewBase
    {
        
        public byte[] Bytes { get; set; }
        public string NomeArquivo { get; set; }
        public string Extensao { get; set; }
        public long Tamanho { get; set; }
        public string MymeType { get; set; }
        public bool Principal { get; set; }
        public string CadastradoPor { get; set; }
        public string AtualizadoPor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
