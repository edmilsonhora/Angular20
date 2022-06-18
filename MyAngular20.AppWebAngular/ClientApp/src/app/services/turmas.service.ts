import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { PaginadorListas } from '../models/paginador-listas';
import { TurmaView } from '../models/turma-view';

@Injectable({
  providedIn: 'root'
})
export class TurmasService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<TurmaView[]>(baseUrl + "turmas/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<TurmaView[]>>(baseUrl + "turmas/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(turma: TurmaView) {
    return this.http.post<TurmaView>(baseUrl + "turmas/salvar", turma);
  }

  excluir(id: number) {
    return this.http.delete(baseUrl + "turmas/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<TurmaView>(baseUrl + "turmas/obterPor/" + id);
  }
}
