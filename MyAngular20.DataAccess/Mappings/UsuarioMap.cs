using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Mappings
{
    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey("Id");
            builder.Property(p => p.NomeCompleto).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.UsuarioNome).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.UsuarioNomeConferencia).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Perfil).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Senha).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.Salt).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataUltimoLogin).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.CadastradoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.AtualizadoPor).HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("bit").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(256).IsRequired();


        }
    }
}
