import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { CursoView } from '../models/curso-view';
import { PaginadorListas } from '../models/paginador-listas';

@Injectable({
  providedIn: 'root'
})
export class CursosService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<CursoView[]>(baseUrl + "cursos/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<CursoView[]>>(baseUrl + "cursos/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(curso: CursoView) {
    return this.http.post<CursoView>(baseUrl + "cursos/salvar", curso);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "cursos/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<CursoView>(baseUrl + "cursos/obterPor/" + id);
  }
}
