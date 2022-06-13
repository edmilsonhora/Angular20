using System.Collections.Generic;

namespace MyAngular20.DomainModel
{
    public class Turma : EntityBase
    {

        public string Nome { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public List<Aluno> Alunos { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            EntidadeObrigatoria(nameof(Curso), Curso);
            base.Validar();
        }

    }

    public interface ITurmaRepository : IRepositoryBase<Turma> { }


}
