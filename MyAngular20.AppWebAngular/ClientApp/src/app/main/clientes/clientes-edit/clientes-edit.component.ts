import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteView } from '../../../models/cliente-view';
import { ClientesService } from '../../../services/clientes.service';


@Component({
  selector: 'app-clientes-edit',
  templateUrl: './clientes-edit.component.html',
  styleUrls: ['./clientes-edit.component.css']
})
export class ClientesEditComponent implements OnInit {


  erros: string[] = [];
  resultado: any;
  entity: ClienteView = new ClienteView();

  constructor(private service: ClientesService, private router: Router, private activedRoute: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.service.obterPor(id)
        .then((result) => {
          this.entity = Object.assign(new ClienteView(), result)
        });
    }

  }

  async salvar(): Promise<void> {

    try {
      this.erros = [];
      this.entity.validar();

      await this.service.salvar(this.entity)
        .then((result) => {
          this.resultado = result;
          this.limpar()
        }, (err) => {
          this.erros = err.error.slice(0, -1).split(';');
        });

    } catch (e: any) {
      this.erros = e.message.slice(0, -1).split(';');
    }

  }

  private limpar(): void {

    if (this.entity.id > 0)
      this.router.navigate(['main/clientes/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new ClienteView();
    }
  }

  apenasAlfanumericos(event: any) {

    let inp = String.fromCharCode(event.keyCode);

    if (/[a-zA-Z0-9 ]/.test(inp)) {
      return true;
    } else {
      event.preventDefault();
      return false;
    }
  }

  private openSnackBar(message: string) {

    let horizontalPosition: MatSnackBarHorizontalPosition = 'center';
    let verticalPosition: MatSnackBarVerticalPosition = 'top';

    this._snackBar.open(message, '', {
      duration: 2000,
      horizontalPosition: horizontalPosition,
      verticalPosition: verticalPosition,
    });
  }



}
