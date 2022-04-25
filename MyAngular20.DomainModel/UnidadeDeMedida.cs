using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.DomainModel
{
   public class UnidadeDeMedida:EntityBase
    {
        public string Nome { get; set; }
        public string Simbolo { get; set; }

        public override void Validar()
        {
            CampoTextoObrigatorio("Nome", Nome);
            CampoTextoObrigatorio("Simbolo", Simbolo);
            base.Validar();
        }
    }

    public interface IUnidadeDeMedidaRepository : IRepositoryBase<UnidadeDeMedida> { }
}
