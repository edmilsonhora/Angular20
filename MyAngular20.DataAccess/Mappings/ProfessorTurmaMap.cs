using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    internal class ProfessorTurmaMap : IEntityTypeConfiguration<ProfessorTurma>
    {
        public void Configure(EntityTypeBuilder<ProfessorTurma> builder)
        {
            builder.ToTable("ProfessoresTurmas");
            builder.HasKey("Id");
            builder.Property(p => p.Id).HasColumnType("int").IsRequired();
            builder.Property(p => p.ProfessorId).HasColumnType("int").IsRequired();
            builder.Property(p => p.TurmaId).HasColumnType("int").IsRequired();
            builder.Property(p => p.HorarioId).HasColumnType("int").IsRequired();           
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
        }
    }
}
