using System.ComponentModel.DataAnnotations.Schema;

namespace MyAngular20.DomainModel
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }
        public string NomeConferencia { get; set; }
        [NotMapped]
        public ICategoriaRepository Repository { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            CampoJahDefinido(Repository.NomeConferenciaExiste(this), nameof(Nome), Nome);

            base.Validar();
        }
    }

    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        bool NomeConferenciaExiste(Categoria categoria);
    }
}
