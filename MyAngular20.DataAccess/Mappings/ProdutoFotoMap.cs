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
    internal class ProdutoFotoMap : IEntityTypeConfiguration<ProdutoFoto>
    {
        public void Configure(EntityTypeBuilder<ProdutoFoto> builder)
        {
            builder.ToTable("ProdutosFotos");
            builder.HasKey("Id");
            builder.Property(p => p.ProdutoId).HasColumnType("int").IsRequired();
            builder.Property(p => p.NomeArquivo).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Principal).HasColumnType("bit").IsRequired();
            builder.Property(p => p.Extensao).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.MymeType).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Tamanho).HasColumnType("int").IsRequired();           
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
        }
    }
}
