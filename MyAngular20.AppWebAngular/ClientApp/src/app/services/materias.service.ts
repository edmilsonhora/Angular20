import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { MateriaView } from '../models/materia-view';
import { PaginadorListas } from '../models/paginador-listas';

@Injectable({
  providedIn: 'root'
})
export class MateriasService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<MateriaView[]>(baseUrl + "materias/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<MateriaView[]>>(baseUrl + "materias/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(materia: MateriaView) {
    return this.http.post<MateriaView>(baseUrl + "materias/salvar", materia);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "materias/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<MateriaView>(baseUrl + "materias/obterPor/" + id);
  }
}
