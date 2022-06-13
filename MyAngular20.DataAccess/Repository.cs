using MyAngular20.DataAccess.Contexts;
using MyAngular20.DataAccess.Repositories;
using MyAngular20.DomainModel;
using System;

namespace MyAngular20.DataAccess
{
    public class Repository : IRepository, IDisposable
    {
        private IClienteRepository clientes;
        private IProdutoRepository produtos;
        private IPedidoItemRepository pedidosItens;
        private ICategoriaRepository categorias;
        private IUsuarioRepository usuarios;
        private IPedidoRepository pedidos;
        private IUnidadeDeMedidaRepository unidadesDeMedidas;
        private IAlunoRepository alunos;
        private IBimestreRepository bimestres;
        private ICursoRepository cursos;
        private IHorarioRepository horarios;
        private IMateriaRepository materias;
        private IMateriaCursoRepository materiasCursos;
        private INotaRepository notas;
        private IProfessorRepository professores;
        private IProfessorTurmaRepository professoresTurmas;
        private ITurmaRepository turmas;
        private IMateriaProfessorRepository materiasProfessores;
        private MyContext context;
        private readonly string _conn;

        public Repository(string conn = "")
        {
            this._conn = conn;
            this.context = new MyContext(_conn);
        }

        IClienteRepository IRepository.Clientes => clientes ?? (clientes = new ClienteRepository(context));

        ICategoriaRepository IRepository.Categorias => categorias ?? (categorias = new CategoriaRepository(context));

        IPedidoRepository IRepository.Pedidos => pedidos ?? (pedidos = new PedidoRepository(context));

        IProdutoRepository IRepository.Produtos => produtos ?? (produtos = new ProdutoRepository(context));

        IPedidoItemRepository IRepository.PedidosItens => pedidosItens ?? (pedidosItens = new PedidoItemRepository(context));

        IUsuarioRepository IRepository.Usuarios => usuarios ?? (usuarios = new UsuarioRepository(context));

        IUnidadeDeMedidaRepository IRepository.UnidadesDeMedida => unidadesDeMedidas ?? (unidadesDeMedidas = new UnidadeDeMedidaRepository(context));

        IAlunoRepository IRepository.Alunos => alunos ?? (alunos = new AlunoRepository(context));

        IBimestreRepository IRepository.Bimestres => bimestres ?? (bimestres = new BimestreRepository(context));

        ICursoRepository IRepository.Cursos => cursos ?? (cursos = new CursoRepository(context));

        IHorarioRepository IRepository.Horarios => horarios ?? (horarios = new HorarioRepository(context));

        IMateriaRepository IRepository.Materias => materias ?? (materias = new MateriaRepository(context));

        IMateriaCursoRepository IRepository.Materias_Cursos => materiasCursos ?? (materiasCursos = new MateriaCursoRepository(context));

        INotaRepository IRepository.Notas => notas ?? (notas = new NotaRepository(context));

        IProfessorRepository IRepository.Professores => professores ?? (professores = new ProfessorRepository(context));

        IProfessorTurmaRepository IRepository.Professores_Turmas => professoresTurmas ?? (professoresTurmas = new ProfessorTurmaRepository(context));

        ITurmaRepository IRepository.Turmas => turmas ?? (turmas = new TurmaRepository(context));

        IMateriaProfessorRepository IRepository.Materias_Professores => materiasProfessores ?? (materiasProfessores = new MateriaProfessorRepository(context));

        void IRepository.RollBack()
        {
            clientes = null;
            categorias = null;
            produtos = null;
            pedidos = null;
            pedidosItens = null;
            usuarios = null;
            unidadesDeMedidas = null;
            alunos = null;
            bimestres = null;
            cursos = null;
            horarios = null;
            materias = null;
            materiasCursos = null;
            notas = null;
            professores = null;
            professoresTurmas = null;
            turmas = null;
            materiasProfessores = null;

            context = new MyContext(_conn);

        }

        void IRepository.SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
