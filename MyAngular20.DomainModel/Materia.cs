using System.Collections.Generic;

namespace MyAngular20.DomainModel
{
    public class Materia:EntityBase
    {       
        public string Nome { get; set; }
        public List<Professor> Professores { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            base.Validar();
        }


    }

    public interface IMateriaRepository : IRepositoryBase<Materia> { }

}
