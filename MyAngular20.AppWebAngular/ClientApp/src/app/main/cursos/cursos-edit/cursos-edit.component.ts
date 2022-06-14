import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CursoView } from '../../../models/curso-view';
import { CursosService } from '../../../services/cursos.service';

@Component({
  selector: 'app-cursos-edit',
  templateUrl: './cursos-edit.component.html',
  styleUrls: ['./cursos-edit.component.css']
})
export class CursosEditComponent implements OnInit {


  erros: string[] = [];
  resultado: any;
  entity: CursoView = new CursoView();

  constructor(private service: CursosService, private router: Router, private activedRoute: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.service.obterPor(id).subscribe((result) => { this.entity = Object.assign(new CursoView(), result) });
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
      this.router.navigate(['main/cursos/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new CursoView();
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
