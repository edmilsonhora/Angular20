import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CursoView } from '../../../models/curso-view';
import { TurmaView } from '../../../models/turma-view';
import { CursosService } from '../../../services/cursos.service';
import { TurmasService } from '../../../services/turmas.service';

@Component({
  selector: 'app-turmas-edit',
  templateUrl: './turmas-edit.component.html',
  styleUrls: ['./turmas-edit.component.css']
})
export class TurmasEditComponent implements OnInit {

  erros: string[] = [];
  resultado: any;
  cursosList: CursoView[] = [];
  entity: TurmaView = new TurmaView();

  constructor(private service: TurmasService, private cursoService: CursosService, private router: Router, private activedRoute: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.service.obterPor(id).subscribe((result) => { this.entity = Object.assign(new TurmaView(), result) });
    }

    this.cursoService.obterTodos().subscribe((result) => { this.cursosList = result });

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
      this.router.navigate(['main/turmas/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new TurmaView();
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
