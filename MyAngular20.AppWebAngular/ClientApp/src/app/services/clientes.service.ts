import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { ClienteView } from '../models/cliente-view';
import { PaginadorListas } from '../models/paginador-listas';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<ClienteView[]>(baseUrl + "clientes/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<ClienteView[]>>(baseUrl + "clientes/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(entity: ClienteView) {
    return this.http.post<ClienteView>(baseUrl + "clientes/salvar", entity);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "clientes/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<ClienteView>(baseUrl + "clientes/obterPor/" + id);
  }

  obterPorNome(nome: string) {

    return this.http.get<ClienteView[]>(baseUrl + "clientes/obterPorNome/" + nome);
  }
}
