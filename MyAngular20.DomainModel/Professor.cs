using System.Collections.Generic;

namespace MyAngular20.DomainModel
{
    public class Professor : EntityBase
    {
       
        public string Nome { get; set; }
        public List<Materia> Materias { get; set; }
        

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            ListaObrigatoria(nameof(Materias), Materias);
            base.Validar();
        }


    }

    public interface IProfessorRepository : IRepositoryBase<Professor> { }


}
