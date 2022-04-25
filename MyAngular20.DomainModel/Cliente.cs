using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DomainModel
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio(nameof(Nome), Nome);
            CampoTextoObrigatorio(nameof(Email), Email);
            EmailEhObrigatorioEmFormatoValido(new ValidaEmail(Email));
            CampoTextoObrigatorio(nameof(Telefone), Telefone);
            base.Validar();
        }

    }

    public interface IClienteRepository : IRepositoryBase<Cliente> {
        List<Cliente> ObterPor(string nome);
    }
}
