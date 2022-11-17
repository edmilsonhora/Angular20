import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { CategoriaView } from '../models/categoria-view';
import { PaginadorListas } from '../models/paginador-listas';
import { firstValueFrom } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<CategoriaView[]>(baseUrl + "categorias/obterTodos");
  }

 async obterPaginado(pageIndex: number, pageSize: number): Promise<PaginadorListas<CategoriaView[]>> {
   let httpResponse = this.http.get<PaginadorListas<CategoriaView[]>>(baseUrl + "categorias/obterPaginado/" + pageIndex + "/" + pageSize);
   return firstValueFrom(httpResponse);
  }

  salvar(categoria: CategoriaView) {
    return this.http.post<CategoriaView>(baseUrl + "categorias/salvar", categoria);

  }

 async excluir(id: number):Promise<any> {
   let httpResponse = this.http.delete(baseUrl + "categorias/excluir/" + id);
   return firstValueFrom(httpResponse);
  }

  obterPor(id: number) {
    return this.http.get<CategoriaView>(baseUrl + "categorias/obterPor/" + id);
  }
}
