﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{

    internal class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");
            builder.HasKey("Id");
            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.CursoId).HasColumnType("int").IsRequired();
            builder.Property(p => p.Limite).HasColumnType("smallint").IsRequired();
            builder.Property(p => p.QtdAtual).HasColumnType("smallint").IsRequired();
            builder.Property(p => p.Ano).HasColumnType("varchar").HasMaxLength(4).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
        }
    }
}
