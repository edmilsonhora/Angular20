using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    internal class HorarioMap : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.ToTable("Horarios");
            builder.HasKey("Id");
            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.DiaDaSemana).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Periodo).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
        }
    }
}
