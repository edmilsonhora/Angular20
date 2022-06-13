using MyAngular20.ApplicationService.Views;

namespace MyAngular20.ApplicationService
{
    public interface IFacade
    {
        void SaveChanges();
        void Roolback();
        void Dispose();
        public ICategoriaFacade Categorias { get; }
        public IClienteFacade Clientes { get; }
        public IUsuarioFacade Usuarios { get; }
        public IProdutoFacade Produtos { get; }
        public IPedidoFacade Pedidos { get; }
        public ILoginFacade Logins { get; }
        public IUnidadeDeMedidaFacade UnidadesDeMedidas { get; }
        public IAlunoFacade Alunos { get; }
        public IBimestreFacade Bimestres { get; }
        public ICursoFacade Cursos {get;}
        public IHorarioFacade Horarios { get; }
        public IMateriaFacade Materias { get; }
        public IMateriaCursoFacade MateriasCursos { get; }
        public IMateriaProfessorFacade  MateriasProfessores { get; }
        public INotaFacade Notas { get; }
        public IProfessorFacade Professores { get; }
        public IProfessorTurmaFacade  ProfessoresTurmas { get; }
        public ITurmaFacade Turmas { get; }
    }
}
