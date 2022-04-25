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
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey("Id");
            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Telefone).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
        }
    }
}
