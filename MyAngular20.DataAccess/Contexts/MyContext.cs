using Microsoft.EntityFrameworkCore;
using MyAngular20.DataAccess.Mappings;
using MyAngular20.DomainModel;

namespace MyAngular20.DataAccess.Contexts
{
    internal class MyContext : DbContext
    {
        private readonly string _conn;
        public MyContext(string conn = "")
        {
            this._conn = conn;

            Database.EnsureCreated();
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (string.IsNullOrWhiteSpace(_conn))
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MyAngular20Db; Trusted_connection=True; MultipleActiveResultSets=True");
            else
                optionsBuilder.UseSqlServer(_conn);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoFotoMap());
            modelBuilder.ApplyConfiguration(new UnidadeDeMedidaMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new BimestreMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new HorarioMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
            modelBuilder.ApplyConfiguration(new MateriaCursoMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new ProfessoresTurmasMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<UnidadeDeMedida> UnidadeDeMedidas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Bimestre> Bimestres { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<MateriaCurso> Materias_Cursos { get; set; }
        public DbSet<ProfessoresTurmas> Professores_Turmas { get; set; }

    }
}
