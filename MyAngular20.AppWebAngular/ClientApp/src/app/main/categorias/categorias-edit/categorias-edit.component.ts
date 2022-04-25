import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriaView } from '../../../models/categoria-view';
import { CategoriasService } from '../../../services/categorias.service';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

@Component({
  selector: 'app-categorias-edit',
  templateUrl: './categorias-edit.component.html',
  styleUrls: ['./categorias-edit.component.css']
})
export class CategoriasEditComponent implements OnInit {


  erros: string[] = [];
  resultado: any;
  entity: CategoriaView = new CategoriaView();

  constructor(private categoriaService: CategoriasService, private router: Router, private activedRoute: ActivatedRoute, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.categoriaService.obterPor(id).subscribe((result) => { this.entity = Object.assign(new CategoriaView(), result) });
    }

  }

  salvar(): void {

    try {
      this.erros = [];
      this.entity.validar();
      this.categoriaService.salvar(this.entity).subscribe((result) => { this.resultado = result },
        (err) => { this.erros = err.error.slice(0, -1).split(';') }, () => { this.limpar() });

    } catch (e: any) {
      this.erros = e.message.slice(0, -1).split(';');
    }

  }

  private limpar(): void {

    if (this.entity.id > 0)
      this.router.navigate(['main/categorias/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new CategoriaView();
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
