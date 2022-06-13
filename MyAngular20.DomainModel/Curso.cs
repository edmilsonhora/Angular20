using System.Collections.Generic;

namespace MyAngular20.DomainModel
{
    public class Curso :EntityBase
    {      
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            base.Validar();
        }

    }

    public interface ICursoRepository : IRepositoryBase<Curso> { }


}
