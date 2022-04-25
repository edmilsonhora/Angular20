import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { PaginadorListas } from '../../../models/paginador-listas';
import { UnidadeView } from '../../../models/unidade-view';
import { UnidadesService } from '../../../services/unidades.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-unidades-list',
  templateUrl: './unidades-list.component.html',
  styleUrls: ['./unidades-list.component.css']
})
export class UnidadesListComponent implements OnInit, AfterViewInit {

  paginador!: PaginadorListas<UnidadeView[]>;
  colunas = ["edit", "nome","simbolo", "cadastradoPor", "dataCadastro", "del"];
  list: UnidadeView[] = [];


  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: UnidadesService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.paginador = { lista: [], totalRegistros: 0 };
    this.carregarDados(0, 6);

  }

  carregarDados(pageIndex: number, pageSize: number) {

    this.service.obterPaginado(pageIndex, pageSize).pipe(tap(dados => { this.paginador = dados })).subscribe((result) => { this.exibir() });

  }

  private exibir(): void {
    this.list = this.paginador.lista;
  }

  confirmaExcluir(item: UnidadeView): void {

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
