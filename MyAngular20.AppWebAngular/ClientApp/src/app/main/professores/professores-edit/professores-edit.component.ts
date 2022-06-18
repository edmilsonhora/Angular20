import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { MateriaView } from '../../../models/materia-view';
import { ProfessorView } from '../../../models/professor-view';
import { MateriasService } from '../../../services/materias.service';
import { ProfessorService } from '../../../services/professor.service';

@Component({
  selector: 'app-professores-edit',
  templateUrl: './professores-edit.component.html',
  styleUrls: ['./professores-edit.component.css']
})
export class ProfessoresEditComponent implements OnInit {

  erros: string[] = [];
  resultado: any;
  materiasList: MateriaView[] = [];
  entity: ProfessorView = new ProfessorView();

  constructor(private service: ProfessorService, private materiaService: MateriasService, private router: Router, private activedRoute: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.service.obterPor(id).subscribe((result) => { this.entity = Object.assign(new ProfessorView(), result) });
    }

    this.materiaService.obterTodos().subscribe((result) => { this.materiasList = result });

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
      this.router.navigate(['main/professores/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new ProfessorView();
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
