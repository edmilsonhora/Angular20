using System.ComponentModel.DataAnnotations.Schema;

namespace MyAngular20.DomainModel
{
    public class ProfessorTurma :EntityBase
    {       
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public Horario Horario { get; set; }
        public int HorarioId { get; set; }
        [NotMapped]
        public IProfessorTurmaRepository Repository { get; set; }

        public override void Validar()
        {
            EntidadeObrigatoria(nameof(Professor), Professor);
            EntidadeObrigatoria(nameof(Turma), Turma);
            EntidadeObrigatoria(nameof(Horario), Horario);

#warning "Implementar Regras para validar as turmas do Professor";

            base.Validar();
        }

    }

    public interface IProfessorTurmaRepository : IRepositoryBase<ProfessorTurma>{ }


}
