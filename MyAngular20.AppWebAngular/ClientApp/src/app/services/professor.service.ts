import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { PaginadorListas } from '../models/paginador-listas';
import { ProfessorView } from '../models/professor-view';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<ProfessorView[]>(baseUrl + "professores/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<ProfessorView[]>>(baseUrl + "professores/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(professor: ProfessorView) {
    return this.http.post<ProfessorView>(baseUrl + "professores/salvar", professor);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "professores/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<ProfessorView>(baseUrl + "professores/obterPor/" + id);
  }
}
