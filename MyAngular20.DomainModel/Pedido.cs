using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DomainModel
{
    public class Pedido : EntityBase
    {
        public Pedido()
        {
            this.Itens = new List<PedidoItem>();
        }
        public DateTime DataEmissao { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public List<PedidoItem> Itens { get; set; }
        public decimal TotalDoPedido { get; set; }

        public override void Validar()
        {
            ListaObrigatoria("Itens", Itens);
            Itens.ForEach(p => p.EhValido(RegrasQuebradas));
            Itens.ForEach(p => p.RegistraAlteracao());
            CampoNumericoMaiorQueZero("Total Pedido", TotalDoPedido);
            base.Validar();
        }
    }

    public interface IPedidoRepository : IRepositoryBase<Pedido> { }
}
