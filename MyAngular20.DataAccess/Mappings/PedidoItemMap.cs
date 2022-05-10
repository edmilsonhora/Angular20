using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    internal class PedidoItemMap : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidosItens");
            builder.HasKey("Id");
            builder.Property(p => p.Descricao).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.PedidoId).HasColumnType("int").IsRequired();
            builder.Property(p => p.ProdutoId).HasColumnType("int").IsRequired();
            builder.Property(p => p.Quantidade).HasColumnType("int").IsRequired();
            builder.Property(p => p.PrecoUnitario).HasColumnType("money").IsRequired();
            builder.Property(p => p.PrecoTotal).HasColumnType("money").IsRequired();

            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
        }
    }
}
