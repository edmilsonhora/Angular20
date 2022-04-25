using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Facades
{
    internal class LoginFacade : ILoginFacade
    {
        private readonly IRepository _repository;
        public LoginFacade(IRepository repository)
        {
            this._repository = repository;
        }

        public void Autenticar(LoginDataView view)
        {
            var usuario = _repository.Usuarios.ObterPor(view.Usuario);
            usuario.AutenticarPor(view.Senha);
            
        }
       
    }
}
