using System.Collections.Generic;

namespace MyAngular20.DomainModel
{
    public class Aluno :EntityBase
    {
       
        public string Nome { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public List<Nota> Notas { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            EntidadeObrigatoria(nameof(Turma), Turma);
            base.Validar();
        }

    }

    public interface IAlunoRepository : IRepositoryBase<Aluno> { }


}
