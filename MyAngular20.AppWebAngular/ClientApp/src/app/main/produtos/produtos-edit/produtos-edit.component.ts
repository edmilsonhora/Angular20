import { AfterViewInit } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriaView } from '../../../models/categoria-view';
import { ProdutoView } from '../../../models/produto-view';
import { UnidadeView } from '../../../models/unidade-view';
import { CategoriasService } from '../../../services/categorias.service';
import { ProdutosService } from '../../../services/produtos.service';
import { UnidadesService } from '../../../services/unidades.service';

@Component({
  selector: 'app-produtos-edit',
  templateUrl: './produtos-edit.component.html',
  styleUrls: ['./produtos-edit.component.css']
})
export class ProdutosEditComponent implements OnInit {

  erros: string[] = [];
  showFileUpload: boolean = true;
  resultado: any;
  categoriasList: CategoriaView[] = [];
  unidadesList: UnidadeView[] = [];
  selectedFile: File[] = [];
  entity: ProdutoView = new ProdutoView();

  constructor(private service: ProdutosService, private categoriasService: CategoriasService, private unidadeService: UnidadesService, private activedRoute: ActivatedRoute, private router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {

    let id = this.activedRoute.snapshot.params['id'];
    if (id !== "0") {
      this.showFileUpload = false;
      this.service.obterPor(id).subscribe((result) => { this.entity = Object.assign(new ProdutoView(), result) });
    }

    this.categoriasService.obterTodos().subscribe((result) => { this.categoriasList = result });
    this.unidadeService.obterTodos().subscribe((result) => { this.unidadesList = result });

  }
    

  onFileSelected(event: any) {

    console.log(event);

    this.selectedFile = <File[]>event.target.files;

  }

  onUpload(): void {

    try {

      this.erros = [];
      this.entity.validar();

      const fd: FormData = new FormData();

      for (let i = 0; i < this.selectedFile.length; i++) {
        let item = this.selectedFile[i];
        fd.append("imagem" + i, item, item.name);
      }

      
      fd.append("produto", JSON.stringify(this.entity));

      this.service.salvar(fd).subscribe((result) => { this.resultado = result },
        (err) => { this.erros = err.error.slice(0, -1).split(';') }, () => { this.limpar() });

    } catch (e: any) {
      this.erros = e.message.slice(0, -1).split(';');
    }
  }


  private limpar(): void {

    if (this.entity.id > 0)
      this.router.navigate(['main/produtos/list']);
    else if (this.erros.length === 0) {
      this.openSnackBar("registro criado com sucesso!")
      this.entity = new ProdutoView();
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
