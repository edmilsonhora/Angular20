using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DomainModel
{
    public class PedidoItem : EntityBase
    {
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }

        protected internal void EhValido(StringBuilder regrasQuebradas)
        {
            
            if (Produto == null || Produto.Id.Equals(0))
                regrasQuebradas.Append($"Produto não identificado.{Environment.NewLine}");

            if (Quantidade < 1)
                regrasQuebradas.Append($"A quantidade tem que ser maior que zero.");

            base.Validar();
        }

        //public override void Validar()
        //{
        //    EntidadeObrigatoria("Produto", Produto);
        //    EntidadeObrigatoria("Pedido", Pedido);
        //    CampoTextoObrigatorio("Descrição", Descricao);
        //    CampoNumericoMaiorQueZero(nameof(Quantidade), Quantidade);
        //    CampoNumericoNaoPodeSerNegativo(nameof(Quantidade), Quantidade);
        //    CampoNumericoMaiorQueZero("Preço Unitário", PrecoUnitario);
        //    CampoNumericoNaoPodeSerNegativo("Preço Unitário", PrecoUnitario);
        //    CampoNumericoMaiorQueZero("Preço Total", PrecoTotal);
        //    CampoNumericoNaoPodeSerNegativo("Preço Total", PrecoTotal);

        //    base.Validar();
        //}

    }

    public interface IPedidoItemRepository : IRepositoryBase<PedidoItem> { }
}
