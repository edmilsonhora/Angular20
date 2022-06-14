import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { baseUrl } from '../../environments/environment';
import { LoginDataView } from '../models/login-data-view';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  estaAutenticado: boolean = false;
  manterLogado: boolean = false;

  constructor(private http: HttpClient) { }

  autenticar(login: LoginDataView) {
    this.manterLogado = login.manterLogado;
    sessionStorage["nomeUsuario"] = login.usuario;
    return this.http.post<any>(baseUrl + "logins/autenticar", login);//.pipe(catchError(this.handleError));
  }

  checarOuCriarAdmin() {
    return this.http.get<boolean>(baseUrl + "logins/checarOuCriarAdmin");
  }


  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}
