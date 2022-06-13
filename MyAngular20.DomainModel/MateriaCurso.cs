namespace MyAngular20.DomainModel
{
    public class MateriaCurso:EntityBase
    {
       
        public Materia Materia { get; set; }
        public int MateriaId { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public double CargaHoraria { get; set; }

        public override void Validar()
        {
            EntidadeObrigatoria(nameof(Materia), Materia);
            EntidadeObrigatoria(nameof(Curso), Curso);
            CampoNumericoMaiorQueZero("Carga Horária", CargaHoraria);
            base.Validar();
        }
    }

    public interface IMateriaCursoRepository : IRepositoryBase<MateriaCurso> { }


}
