import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { PaginadorListas } from '../models/paginador-listas';
import { UsuarioView } from '../models/usuario-view';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {
    

  constructor(private http: HttpClient) { }

  obterUsuario() {

    let nomeUsuario = sessionStorage["nomeUsuario"];

    return this.http.get<UsuarioView>(baseUrl + "usuarios/obterPor/" + nomeUsuario);

  }


  obterTodos() {
    return this.http.get<UsuarioView[]>(baseUrl + "usuarios/obterTodos");
  }

 async obterPaginado(pageIndex: number, pageSize: number): Promise<PaginadorListas<UsuarioView[]>> {
   let httpResponse = this.http.get<PaginadorListas<UsuarioView[]>>(baseUrl + "usuarios/obterPaginado/" + pageIndex + "/" + pageSize);
   return firstValueFrom(httpResponse);
  }

  salvar(usuario: UsuarioView) {
    return this.http.post<UsuarioView>(baseUrl + "usuarios/salvar", usuario);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "usuarios/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<UsuarioView>(baseUrl + "usuarios/obterPor/" + id);
  }

  



}
