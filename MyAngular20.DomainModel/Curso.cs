using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAngular20.DomainModel
{
    public class Curso : EntityBase
    {
        public string Nome { get; set; }
        public string NomeConferencia { get; set; }
        public List<Turma> Turmas { get; set; }

        [NotMapped]
        public ICursoRepository Repository { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            CampoJahDefinido(Repository.NomeConferenciaExiste(this), nameof(Nome), Nome);
            base.Validar();
        }

    }

    public interface ICursoRepository : IRepositoryBase<Curso> {

        bool NomeConferenciaExiste(Curso curso);
    }


}
