import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { ClienteView } from '../models/cliente-view';
import { PaginadorListas } from '../models/paginador-listas';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<ClienteView[]>(baseUrl + "clientes/obterTodos");
  }

  async obterPaginado(pageIndex: number, pageSize: number): Promise<PaginadorListas<ClienteView[]>> {
    let httpResponse = this.http.get<PaginadorListas<ClienteView[]>>(baseUrl + "clientes/obterPaginado/" + pageIndex + "/" + pageSize);
    return firstValueFrom(httpResponse);
  }

  async salvar(entity: ClienteView): Promise<any> {
    let httpResponse = this.http.post<ClienteView>(baseUrl + "clientes/salvar", entity);
    return firstValueFrom(httpResponse);

  }

 async excluir(id: number):Promise<any> {
    let httpResponse = this.http.delete(baseUrl + "clientes/excluir/" + id);
    return firstValueFrom(httpResponse);
  }

  async obterPor(id: number): Promise<ClienteView> {
    let httpResponse = this.http.get<ClienteView>(baseUrl + "clientes/obterPor/" + id);
    return firstValueFrom(httpResponse);
  }

  async obterPorNome(nome: string): Promise<ClienteView[]> {

    let httpResponse = this.http.get<ClienteView[]>(baseUrl + "clientes/obterPorNome/" + nome);
    return firstValueFrom(httpResponse);
  }
}
