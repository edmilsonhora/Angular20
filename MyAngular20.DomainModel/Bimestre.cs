namespace MyAngular20.DomainModel
{
    public class Bimestre :EntityBase
    {
       
        public string Nome { get; set; }
        public int Ano { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            CampoNumericoMaiorQueZero(nameof(Ano), Ano);
            base.Validar();
        }
    }

    public interface IBimestreRepository : IRepositoryBase<Bimestre> { }

}
