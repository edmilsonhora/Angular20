namespace MyAngular20.DomainModel
{
    public class Nota:EntityBase
    {
       
        public double Valor { get; set; }
        public int MateriaId { get; set; }
        public int AlunoId { get; set; }
        public int BimestreId { get; set; }
        public Materia Materia { get; set; }
        public Aluno Aluno { get; set; }
        public Bimestre Bimestre { get; set; }

        public override void Validar()
        {
            EntidadeObrigatoria(nameof(Materia), Materia);
            EntidadeObrigatoria(nameof(Aluno), Aluno);
            EntidadeObrigatoria(nameof(Bimestre), Bimestre);
            CampoNumericoNaoPodeSerNegativo("Nota", Valor);
            base.Validar();
        }
    }

    public interface INotaRepository : IRepositoryBase<Nota> { }


}
