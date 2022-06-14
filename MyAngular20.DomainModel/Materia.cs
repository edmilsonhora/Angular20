using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAngular20.DomainModel
{
    public class Materia : EntityBase
    {
        public string Nome { get; set; }
        public string NomeConferencia { get; set; }
        public List<MateriaProfessor> Professores { get; set; }

        [NotMapped]
        public IMateriaRepository Repository { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            CampoJahDefinido(Repository.NomeConferenciaExiste(this), nameof(Nome), Nome);
            base.Validar();
        }


    }

    public interface IMateriaRepository : IRepositoryBase<Materia>
    {
        List<Materia> ObterPor(int[] materiasIds);
        bool NomeConferenciaExiste(Materia materia);
    }

}
