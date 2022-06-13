using MyAngular20.ApplicationService.Facades;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DataAccess;
using MyAngular20.DomainModel;

namespace MyAngular20.ApplicationService
{
    public class Facade : IFacade
    {
        private ICategoriaFacade categorias;
        private IClienteFacade clientes;
        private IPedidoFacade pedidos;
        private IProdutoFacade produtos;
        private IUsuarioFacade usuarios;
        private ILoginFacade logins;
        private IUnidadeDeMedidaFacade unidadesDeMedidas;
        private IAlunoFacade alunos;
        private IBimestreFacade bimestres;
        private ICursoFacade cursos;
        private IHorarioFacade horarios;
        private IMateriaFacade materias;
        private IMateriaCursoFacade materiasCursos;
        private IMateriaProfessorFacade materiasProfessores;
        private INotaFacade notas;
        private IProfessorFacade professores;
        private IProfessorTurmaFacade professoresTurmas;
        private ITurmaFacade turmas;
        private readonly string _conn;
        private IRepository repository;
        public Facade(string conn = "")
        {
            this._conn = conn;
            repository = new Repository(_conn);
        }

        ICategoriaFacade IFacade.Categorias => categorias ?? (categorias = new CategoriaFacade(repository));

        IClienteFacade IFacade.Clientes => clientes ?? (clientes = new ClienteFacade(repository));

        IUsuarioFacade IFacade.Usuarios => usuarios ?? (usuarios = new UsuarioFacade(repository));

        IProdutoFacade IFacade.Produtos => produtos ?? (produtos = new ProdutoFacade(repository));

        IPedidoFacade IFacade.Pedidos => pedidos ?? (pedidos = new PedidoFacade(repository));

        ILoginFacade IFacade.Logins => logins ?? (logins = new LoginFacade(repository));
        IUnidadeDeMedidaFacade IFacade.UnidadesDeMedidas => unidadesDeMedidas ?? (unidadesDeMedidas = new UnidadeDeMedidaFacade(repository));

        IAlunoFacade IFacade.Alunos => alunos ?? (alunos = new AlunoFacade(repository));

        IBimestreFacade IFacade.Bimestres => bimestres ?? (bimestres = new BimestreFacade(repository));

        ICursoFacade IFacade.Cursos => cursos ?? (cursos = new CursoFacade(repository));

        IHorarioFacade IFacade.Horarios => horarios ?? (horarios = new HorarioFacade(repository));

        IMateriaFacade IFacade.Materias => materias ?? (materias = new MateriaFacade(repository));

        IMateriaCursoFacade IFacade.MateriasCursos => materiasCursos ?? (materiasCursos = new MateriaCursoFacade(repository));

        IMateriaProfessorFacade IFacade.MateriasProfessores => materiasProfessores ?? (materiasProfessores = new MateriaProfessorFacade(repository));

        INotaFacade IFacade.Notas => notas ?? (notas = new NotaFacade(repository));

        IProfessorFacade IFacade.Professores => professores ?? (professores = new ProfessorFacade(repository));

        IProfessorTurmaFacade IFacade.ProfessoresTurmas => professoresTurmas ?? (professoresTurmas = new ProfessorTurmaFacade(repository));

        ITurmaFacade IFacade.Turmas => turmas ?? (turmas = new TurmaFacade(repository));

        void IFacade.Roolback()
        {
            categorias = null;
            clientes = null;
            pedidos = null;
            produtos = null;
            usuarios = null;
            logins = null;
            unidadesDeMedidas = null;
            alunos = null;
            bimestres = null;
            cursos = null;
            horarios = null;
            materias = null;
            materiasCursos = null;
            materiasProfessores = null;
            notas = null;
            professores = null;
            professoresTurmas = null;
            turmas = null;
            repository.RollBack();
            repository = new Repository(_conn);
        }
        void IFacade.SaveChanges()
        {
            repository.SaveChanges();
        }
        void IFacade.Dispose()
        {
            repository.Dispose();
        }
    }
}
