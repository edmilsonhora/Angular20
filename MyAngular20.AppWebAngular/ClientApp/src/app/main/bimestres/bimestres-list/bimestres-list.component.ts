import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { BimestreView } from '../../../models/bimestre-view';
import { PaginadorListas } from '../../../models/paginador-listas';
import { BimestresService } from '../../../services/bimestres.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-bimestres-list',
  templateUrl: './bimestres-list.component.html',
  styleUrls: ['./bimestres-list.component.css']
})
export class BimestresListComponent implements OnInit, AfterViewInit {


  paginador!: PaginadorListas<BimestreView[]>;
  colunas = ["edit", "nome", "ano", "cadastradoPor", "dataCadastro", "del"];
  list: BimestreView[] = [];

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: BimestresService, private dialog: MatDialog) { }

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

  confirmaExcluir(item: BimestreView): void {

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
