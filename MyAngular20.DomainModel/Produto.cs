using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAngular20.DomainModel
{
    public class Produto : EntityBase
    {

        public Produto()
        {
            Fotos = new List<ProdutoFoto>();
        }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string DescricaoConferencia { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Ativo { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public decimal QtdEmEstoque { get; set; }
        public UnidadeDeMedida UnidadeDeMedida { get; set; }
        public int UnidadeDeMedidaId { get; set; }
        public List<ProdutoFoto> Fotos { get; set; }
        [NotMapped]
        public IProdutoRepository Repository { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Descricao), Descricao);
            CampoNumericoMaiorQueZero("Preço Unitário", PrecoUnitario);
            CampoNumericoNaoPodeSerNegativo("Preço Unitário", PrecoUnitario);
            CampoNumericoMaiorQueZero("Qtd. Estoque", QtdEmEstoque);
            CampoNumericoNaoPodeSerNegativo("Qtd. Estoque", QtdEmEstoque);
            EntidadeObrigatoria("Unidade de Medidad", UnidadeDeMedida);
            EntidadeObrigatoria("Categoria", Categoria);
            ListaObrigatoria("Fotos", Fotos);
            CampoJahDefinido(Repository.NomeConferenciaExiste(this), nameof(Descricao), Descricao);
            CampoJahDefinido(Repository.CodigoJahExiste(this), nameof(Codigo), Codigo);


            base.Validar();
        }
    }

    public interface IProdutoRepository : IRepositoryBase<Produto>
    {

        bool NomeConferenciaExiste(Produto produto);
        bool CodigoJahExiste(Produto produto);

    }
}
