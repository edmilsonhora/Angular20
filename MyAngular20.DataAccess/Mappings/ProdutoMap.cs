using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    internal class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey("Id");
            builder.Property(p => p.Codigo).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DescricaoConferencia).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("bit").IsRequired();
            builder.Property(p => p.CategoriaId).HasColumnType("int").IsRequired();
            builder.Property(p => p.UnidadeDeMedidaId).HasColumnType("int").IsRequired();
            builder.Property(p => p.PrecoUnitario).HasColumnType("money").IsRequired();
            builder.Property(p => p.QtdEmEstoque).HasColumnType("int").IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
        }
    }
}
