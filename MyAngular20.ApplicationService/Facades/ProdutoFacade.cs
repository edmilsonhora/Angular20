using MyAngular20.ApplicationService.Adapters;
using MyAngular20.ApplicationService.Views;
using MyAngular20.CommonPlace;
using MyAngular20.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAngular20.ApplicationService.Facades
{
    internal class ProdutoFacade : IProdutoFacade
    {
        private readonly IRepository _repository;

        public ProdutoFacade(IRepository repository)
        {
            this._repository = repository;
        }
        void IViewFacade<ProdutoView>.Excluir(int id)
        {
            var obj = _repository.Produtos.ObterPor(id);
            if (obj == null) return;
            _repository.Produtos.Excluir(obj);
        }

        ProdutoView IViewFacade<ProdutoView>.ObterPor(int id)
        {
            return _repository.Produtos.ObterPor(id).ConvertToView();
        }

        PaginadorDeListas<ProdutoView> IViewFacade<ProdutoView>.ObterPaginado(int pageIndex, int pageSize)
        {
            int totalRegistros = _repository.Produtos.TotalDeRegistros();
            var lista = _repository.Produtos.ObterPaginado(pageIndex, pageSize).ConvertToView();

            return new PaginadorDeListas<ProdutoView>(lista, totalRegistros);
        }

        List<ProdutoView> IViewFacade<ProdutoView>.ObterTodos()
        {
            return _repository.Produtos.ObterTodos().ConvertToView();
        }

        void IViewFacade<ProdutoView>.Salvar(ProdutoView view)
        {
            throw new NotImplementedException();
        }

        public void Salvar(ProdutoView view, List<ProdutoFotoView> listaFotos)
        {
            var obj = view.Id == 0 ? new Produto() : _repository.Produtos.ObterPor(view.Id);
            obj.Descricao = view.Descricao;
            obj.DescricaoConferencia = Helper.GetConference(view.Descricao);
            obj.Codigo = view.Codigo;
            obj.PrecoUnitario = view.PrecoUnitario;
            obj.Ativo = view.Ativo;
            obj.Categoria = _repository.Categorias.ObterPor(view.CategoriaId);
            obj.UnidadeDeMedida = _repository.UnidadesDeMedida.ObterPor(view.UnidadeDeMedidaId);
            obj.AtualizadoPor = view.AtualizadoPor;
            obj.QtdEmEstoque = view.QtdEmEstoque;
            obj.Repository = _repository.Produtos;
            obj.Fotos.AddRange(ObterFotos(listaFotos));
            obj.RegistraAlteracao();

            obj.Validar();

            _repository.Produtos.Salvar(obj);
        }

        private List<ProdutoFoto> ObterFotos(List<ProdutoFotoView> listaFotos)
        {
            var novalista = new List<ProdutoFoto>();

            foreach (var item in listaFotos)
            {
                novalista.Add(ObterFoto(item));
            }

            return novalista;
        }

        private ProdutoFoto ObterFoto(ProdutoFotoView item)
        {
            var obj = new ProdutoFoto()
            {
                Bytes = item.Bytes,
                Extensao = item.Extensao,
                MymeType = item.MymeType,
                NomeArquivo = item.NomeArquivo,
                Tamanho = item.Tamanho,                

            };
            obj.RegistraAlteracao();
            return obj;
        }
    }
}
