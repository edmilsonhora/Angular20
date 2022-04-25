import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { CategoriaView } from '../models/categoria-view';
import { PaginadorListas } from '../models/paginador-listas';


@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<CategoriaView[]>(baseUrl + "categorias/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<CategoriaView[]>>(baseUrl + "categorias/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(categoria: CategoriaView) {
    return this.http.post<CategoriaView>(baseUrl + "categorias/salvar", categoria);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "categorias/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<CategoriaView>(baseUrl + "categorias/obterPor/" + id);
  }
}
