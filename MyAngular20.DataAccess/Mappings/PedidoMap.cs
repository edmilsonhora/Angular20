using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DataAccess.Mappings
{
    internal class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey("Id");
            builder.Property(p => p.DataEmissao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.TotalDoPedido).HasColumnType("money").IsRequired();
            builder.Property(p => p.ClienteId).HasColumnType("int").IsRequired();            
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
        }
    }
}
