import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../../environments/environment';
import { BimestreView } from '../models/bimestre-view';
import { PaginadorListas } from '../models/paginador-listas';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BimestresService {

  constructor(private http: HttpClient) { }

  obterTodos() {
    return this.http.get<BimestreView[]>(baseUrl + "bimestres/obterTodos");
  }

 async obterPaginado(pageIndex: number, pageSize: number): Promise<PaginadorListas<BimestreView[]>> {
   let httpResponse = this.http.get<PaginadorListas<BimestreView[]>>(baseUrl + "bimestres/obterPaginado/" + pageIndex + "/" + pageSize);
   return firstValueFrom(httpResponse);
  }

  salvar(bimestre: BimestreView) {
    return this.http.post<BimestreView>(baseUrl + "bimestres/salvar", bimestre);

  }

 async excluir(id: number):Promise<any> {
   let httpResponse = this.http.delete(baseUrl + "bimestres/excluir/" + id);
   return firstValueFrom(httpResponse);
  }

  obterPor(id: number) {
    return this.http.get<BimestreView>(baseUrl + "bimestres/obterPor/" + id);
  }
}
