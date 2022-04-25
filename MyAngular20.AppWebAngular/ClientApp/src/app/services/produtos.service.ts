import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { PaginadorListas } from '../models/paginador-listas';
import { ProdutoView } from '../models/produto-view';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<ProdutoView[]>(baseUrl + "produtos/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<ProdutoView[]>>(baseUrl + "produtos/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(entity: any) {
    return this.http.post(baseUrl + "produtos/salvar", entity);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "produtos/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<ProdutoView>(baseUrl + "produtos/obterPor/" + id);
  }

  obterPorNome(nome: string) {

    return this.http.get<ProdutoView[]>(baseUrl + "produtos/obterPorNome/" + nome);
  }
}
