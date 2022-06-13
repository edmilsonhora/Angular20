namespace MyAngular20.DomainModel
{
    public class Horario :EntityBase
    {       
        public string DiaDaSemana { get; set; }
        public string Periodo { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio("Dia da Semana", DiaDaSemana);
            CampoTextoObrigatorio("Período", Periodo);
            base.Validar();
        }
    }

    public interface IHorarioRepository : IRepositoryBase<Horario> { }


}
