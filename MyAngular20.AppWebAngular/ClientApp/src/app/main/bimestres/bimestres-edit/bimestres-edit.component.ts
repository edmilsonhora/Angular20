import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { BimestreView } from '../../../models/bimestre-view';
import { BimestresService } from '../../../services/bimestres.service';

@Component({
  selector: 'app-bimestres-edit',
  templateUrl: './bimestres-edit.component.html',
  styleUrls: ['./bimestres-edit.component.css']
})
export class BimestresEditComponent implements OnInit {


  erros: string[] = [];
  resultado: any;
  entity: BimestreView = new BimestreView();

  constructor(private service: BimestresService, private router: Router, private activedRoute: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.service.obterPor(id).subscribe((result) => { this.entity = Object.assign(new BimestreView(), result) });
    }

  }

  salvar(): void {

    try {
      this.erros = [];
      this.entity.validar();
      this.service.salvar(this.entity).subscribe((result) => { this.resultado = result },
        (err) => { this.erros = err.error.slice(0, -1).split(';') }, () => { this.limpar() });

    } catch (e: any) {
      this.erros = e.message.slice(0, -1).split(';');
    }

  }

  private limpar(): void {

    if (this.entity.id > 0)
      this.router.navigate(['main/bimestres/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new BimestreView();
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
