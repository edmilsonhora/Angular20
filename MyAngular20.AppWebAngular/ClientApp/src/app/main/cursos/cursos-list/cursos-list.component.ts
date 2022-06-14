import { AfterViewInit, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { CursoView } from '../../../models/curso-view';
import { PaginadorListas } from '../../../models/paginador-listas';
import { CursosService } from '../../../services/cursos.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-cursos-list',
  templateUrl: './cursos-list.component.html',
  styleUrls: ['./cursos-list.component.css']
})
export class CursosListComponent implements OnInit, AfterViewInit {

  paginador!: PaginadorListas<CursoView[]>;
  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];
  list: CursoView[] = [];

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: CursosService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.paginador = { lista: [], totalRegistros: 0 };
    this.carregarDados(this.paginator?.pageIndex ?? 0, this.paginator?.pageSize ?? 6);

  }

  carregarDados(pageIndex: number, pageSize: number) {

    this.service.obterPaginado(pageIndex, pageSize).pipe(tap(dados => { this.paginador = dados })).subscribe((result) => { this.exibir() });

  }

  private exibir(): void {
    this.list = this.paginador.lista;
  }

  confirmaExcluir(item: CursoView): void {

    let dialogRef = this.dialog.open(ConfirmaExclusaoComponent, { width: 'auto', data: { nome: item.nome } });
    dialogRef.afterClosed().subscribe((result) => { this.excluir(result, item.id) });
  }

  private excluir(result: any, id: number) {
    if (result !== "true") return;
    this.service.excluir(id).subscribe((result) => { }, (err) => { }, () => { this.carregarDados(this.paginator.pageIndex, this.paginator.pageSize) });
  }

  ngAfterViewInit(): void {
    this.paginator.page.pipe(tap(() => this.carregarDados(this.paginator.pageIndex, this.paginator.pageSize))).subscribe();
  }

}
