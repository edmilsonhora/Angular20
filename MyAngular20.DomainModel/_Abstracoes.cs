using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyAngular20.DomainModel
{
    public abstract class EntityBase
    {
        protected StringBuilder RegrasQuebradas = new StringBuilder();
        public int Id { get; set; }
        public string CadastradoPor { get; set; }
        public string AtualizadoPor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual void Validar()
        {
            CampoTextoObrigatorio("Atualizado Por", AtualizadoPor);

            if (RegrasQuebradas.Length > 0)
                throw new ApplicationException(RegrasQuebradas.ToString());
        }
        public void RegistraAlteracao()
        {

            if (Id.Equals(0))
            {
                CadastradoPor = AtualizadoPor;
                DataCadastro = DateTime.Now;
            }

            DataAtualizacao = DateTime.Now;
        }
        protected void CampoTextoObrigatorio(string nomeDoCampo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                RegrasQuebradas.Append($"O campo {nomeDoCampo} é obrigatório.{Environment.NewLine}");
        }
        protected void CampoJahDefinido(bool jahExiste, string nomeCampo, string valor)
        {
            if (jahExiste)
                RegrasQuebradas.Append($"O valor {valor} já existe na base de dados para o campo {nomeCampo}.{Environment.NewLine}");
        }
        protected void ListaObrigatoria<T>(string nomeDaLista, List<T> lista)
        {
            if (lista != null && lista.Count < 1)
                RegrasQuebradas.Append($"A lista de {nomeDaLista} deve ter pelo menos 1 item.{Environment.NewLine}");

        }
        protected void EntidadeObrigatoria<T>(string nomeEntidade, T entidade) where T : EntityBase
        {
            if (entidade == null)
                RegrasQuebradas.Append($"A entidade {nomeEntidade} não foi informada.{Environment.NewLine}");
            else if (entidade.Id.Equals(0))
                RegrasQuebradas.Append($"Selecione um(a) {nomeEntidade}.{Environment.NewLine}");
        }
        protected void CampoNumericoMaiorQueZero(string nomeDoCampo, int valor)
        {
            if (valor < 1)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor maior que zero.{Environment.NewLine}");
        }
        protected void CampoNumericoMaiorQueZero(string nomeDoCampo, double valor)
        {
            if (valor < 1d)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor maior que zero.{Environment.NewLine}");
        }
        protected void CampoNumericoMaiorQueZero(string nomeDoCampo, decimal valor)
        {
            if (valor < 1m)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor maior que zero.{Environment.NewLine}");
        }
        protected void CampoNumericoNaoPodeSerNegativo(string nomeDoCampo, decimal valor)
        {
            if (valor < 0)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor zero ou positivo.{Environment.NewLine}");
        }
        protected void CampoNumericoNaoPodeSerNegativo(string nomeDoCampo, double valor)
        {
            if (valor < 0)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor zero ou positivo.{Environment.NewLine}");
        }
        protected void CampoNumericoNaoPodeSerNegativo(string nomeDoCampo, int valor)
        {
            if (valor < 0)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} deve ter valor zero ou positivo.{Environment.NewLine}");
        }
        protected void CampoSoAceitaNumeros(string nomeDoCampo, string valor)
        {
            if (valor.Any(p => !char.IsDigit(p)))
                RegrasQuebradas.Append($"O campo {nomeDoCampo} só aceita números.{Environment.NewLine}");
        }
        protected void CampoDataNaoPodeEstarNoPassado(string nomeDoCampo, DateTime valor)
        {
            if (DateTime.Today > valor)
                RegrasQuebradas.Append($"O campo {nomeDoCampo} só aceita datas futuras.{Environment.NewLine}");
        }
        protected void EmailEhObrigatorioEmFormatoValido(ValidaEmail email)
        {
            if (email != null && !email.EhFormatoValido())
                RegrasQuebradas.Append($"O email não esta em formato válido!{Environment.NewLine}");
        }
        protected class ValidaEmail
        {
            protected internal ValidaEmail() { }
            public ValidaEmail(string endereco)
            {
                Endereco = endereco;
            }

            public string Endereco { get; private set; }

            public bool EhFormatoValido()
            {
                if (string.IsNullOrWhiteSpace(Endereco))
                    return false;

                var expression = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                //var expression = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
                return expression.IsMatch(Endereco);
            }
        }


    }
    public interface IRepositoryBase<T> where T : EntityBase
    {
        void Salvar(T entity);
        void Excluir(T entity);
        T ObterPor(int id);
        List<T> ObterPaginado(int pageIndex, int pageSize);
        List<T> ObterTodos();
        int TotalDeRegistros();
    }
    public interface IRepository
    {
        public void SaveChanges();
        public void RollBack();
        public void Dispose();
        public IClienteRepository Clientes { get; }
        public ICategoriaRepository Categorias { get; }
        public IPedidoRepository Pedidos { get; }
        public IProdutoRepository Produtos { get; }
        public IPedidoItemRepository PedidosItens { get; }
        public IUsuarioRepository Usuarios { get; }
        public IUnidadeDeMedidaRepository UnidadesDeMedida { get; }
        public IAlunoRepository Alunos { get; }
        public IBimestreRepository Bimestres { get; }
        public ICursoRepository Cursos { get; }
        public IHorarioRepository Horarios { get; }
        public IMateriaRepository Materias { get; }
        public IMateriaCursoRepository Materias_Cursos { get; }
        public INotaRepository Notas { get; }
        public IProfessorRepository Professores { get; }
        public IProfessorTurmaRepository Professores_Turmas { get; }
        public ITurmaRepository Turmas { get; }
        public IMateriaProfessorRepository Materias_Professores { get; }


    }


}
