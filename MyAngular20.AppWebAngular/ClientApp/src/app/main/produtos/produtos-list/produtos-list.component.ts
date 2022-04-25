import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { PaginadorListas } from '../../../models/paginador-listas';
import { ProdutoView } from '../../../models/produto-view';
import { ProdutosService } from '../../../services/produtos.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-produtos-list',
  templateUrl: './produtos-list.component.html',
  styleUrls: ['./produtos-list.component.css']
})
export class ProdutosListComponent implements OnInit {
  paginador!: PaginadorListas<ProdutoView[]>;
  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];
  list: ProdutoView[] = [];

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: ProdutosService, private dialog: MatDialog) { }

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

  confirmaExcluir(item: ProdutoView): void {

    let dialogRef = this.dialog.open(ConfirmaExclusaoComponent, { width: 'auto', data: { nome: item.descricao } });
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
