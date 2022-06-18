using System.Collections.Generic;
using System;
using System.Text;

namespace MyAngular20.DomainModel
{
    public class Turma : EntityBase
    {

        public string Nome { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public  short  Limite { get; set; }
        public short QtdAtual { get; set; }
        public string Ano { get; set; }
        public List<Aluno> Alunos { get; set; }

        public override void Validar()
        {
            CampoNumericoMaiorQueZero(nameof(Limite), Limite);
            CampoTextoObrigatorio(nameof(Nome), Nome);
            EntidadeObrigatoria(nameof(Curso), Curso);
            CampoTextoObrigatorio(nameof(Ano), Ano);
            base.Validar();
        }

        protected internal void AddQtdAtualDeAlunos(StringBuilder regrasQuebradas)
        {
            QtdAtual++;
            if (QtdAtual > Limite)
                regrasQuebradas.Append($"A quantidade de alunos é maior que o limite da turma.{Environment.NewLine}");
        }

    }

    public interface ITurmaRepository : IRepositoryBase<Turma> { }


}
