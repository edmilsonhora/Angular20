using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
   public class UnidadeDeMedidaView:ViewBase
    {
        public string Nome { get; set; }
        public string Simbolo { get; set; }
        public string CadastradoPor { get; set; }
        public string DataCadastro { get; set; }
        public string AtualizadoPor { get; set; }
        public string DataAtualizacao { get; set; }
    }

    public interface IUnidadeDeMedidaFacade:IViewFacade<UnidadeDeMedidaView>
    {

    }
}
