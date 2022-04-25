import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { PaginadorListas } from '../models/paginador-listas';
import { UnidadeView } from '../models/unidade-view';

@Injectable({
  providedIn: 'root'
})
export class UnidadesService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<UnidadeView[]>(baseUrl + "unidadesdemedidas/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<UnidadeView[]>>(baseUrl + "unidadesdemedidas/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(entity: UnidadeView) {
    return this.http.post<UnidadeView>(baseUrl + "unidadesdemedidas/salvar", entity);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "unidadesdemedidas/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<UnidadeView>(baseUrl + "unidadesdemedidas/obterPor/" + id);
  }

  obterPorNome(nome: string) {

    return this.http.get<UnidadeView[]>(baseUrl + "unidadesdemedidas/obterPorNome/" + nome);
  }
}
