namespace MyAngular20.DomainModel
{
    public class MateriaProfessor : EntityBase
    {
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public override void Validar()
        {
            EntidadeObrigatoria(nameof(Materia), Materia);
            EntidadeObrigatoria(nameof(Professor), Professor);
            base.Validar();
        }
    }

    public interface IMateriaProfessorRepository : IRepositoryBase<MateriaProfessor> { }
}
