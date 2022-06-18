using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    //internal class MateriaProfessorMap : IEntityTypeConfiguration<MateriaProfessor>
    //{
    //    public void Configure(EntityTypeBuilder<MateriaProfessor> builder)
    //    {
    //        builder.ToTable("MateriasProfessores");
    //        builder.HasKey("Id");
    //        builder.Property(p => p.Id).HasColumnType("int").IsRequired();
    //        builder.Property(p => p.MateriaId).HasColumnType("int").IsRequired();
    //        builder.Property(p => p.ProfessorId).HasColumnType("int").IsRequired();
    //        builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
    //        builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
    //        builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
    //        builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
    //    }
    //}
}
