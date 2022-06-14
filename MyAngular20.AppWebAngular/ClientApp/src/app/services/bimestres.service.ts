import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { BimestreView } from '../models/bimestre-view';
import { PaginadorListas } from '../models/paginador-listas';

@Injectable({
  providedIn: 'root'
})
export class BimestresService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<BimestreView[]>(baseUrl + "bimestres/obterTodos");
  }

  obterPaginado(pageIndex: number, pageSize: number) {
    return this.http.get<PaginadorListas<BimestreView[]>>(baseUrl + "bimestres/obterPaginado/" + pageIndex + "/" + pageSize);
  }

  salvar(bimestre: BimestreView) {
    return this.http.post<BimestreView>(baseUrl + "bimestres/salvar", bimestre);

  }

  excluir(id: number) {

    return this.http.delete(baseUrl + "bimestres/excluir/" + id);
  }

  obterPor(id: number) {
    return this.http.get<BimestreView>(baseUrl + "bimestres/obterPor/" + id);
  }
}
