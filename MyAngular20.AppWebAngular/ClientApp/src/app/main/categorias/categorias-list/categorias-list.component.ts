import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { CategoriaView } from '../../../models/categoria-view';
import { PaginadorListas } from '../../../models/paginador-listas';
import { CategoriasService } from '../../../services/categorias.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-categorias-list',
  templateUrl: './categorias-list.component.html',
  styleUrls: ['./categorias-list.component.css']
})
export class CategoriasListComponent implements OnInit, AfterViewInit {
  
  paginador!: PaginadorListas<CategoriaView[]>;
  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];
  list: CategoriaView[] = [];

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: CategoriasService, private dialog:MatDialog) { }

  ngOnInit(): void {
    this.paginador = { lista: [], totalRegistros: 0 };
    this.carregarDados(this.paginator?.pageIndex ?? 0, this.paginator?.pageSize ?? 6);
    
  }

 async carregarDados(pageIndex: number, pageSize: number) {

   await this.service.obterPaginado(pageIndex, pageSize).then(dados => { this.paginador = dados; this.exibir() }, (error) => { console.log(error) });
    
  }

  private exibir(): void {    
    this.list = this.paginador.lista;
  }

  confirmaExcluir(item:CategoriaView): void {

    let dialogRef = this.dialog.open(ConfirmaExclusaoComponent, { width: 'auto', data: { nome: item.nome } });
    dialogRef.afterClosed().subscribe((result) => { this.excluir(result, item.id) });     
  }

  private async excluir(result: any, id: number) {
    if (result !== "true") return;
    await this.service.excluir(id).then((result) => { this.carregarDados(this.paginator.pageIndex, this.paginator.pageSize) }, (err) => { });
  }

  ngAfterViewInit(): void {
    this.paginator.page.pipe(tap(() => this.carregarDados(this.paginator.pageIndex, this.paginator.pageSize))).subscribe();
  }
}
