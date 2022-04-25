using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Views
{
   public class LoginDataView
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public interface ILoginFacade
    {
        void Autenticar(LoginDataView view);
        
    }
}
