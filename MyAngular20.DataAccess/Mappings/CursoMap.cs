using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    internal class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Cursos");
            builder.HasKey("Id");
            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(256).IsRequired();            
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
        }
    }
}
