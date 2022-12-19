import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { ClienteView } from '../../../models/cliente-view';
import { PaginadorListas } from '../../../models/paginador-listas';
import { ClientesService } from '../../../services/clientes.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-clientes-list',
  templateUrl: './clientes-list.component.html',
  styleUrls: ['./clientes-list.component.css']
})
export class ClientesListComponent implements OnInit, AfterViewInit {
  paginador!: PaginadorListas<ClienteView[]>;
  colunas = ["edit", "nome", "email","telefone", "cadastradoPor", "dataCadastro", "del"];
  list: ClienteView[] = [];


  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: ClientesService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.paginador = { lista: [], totalRegistros: 0 };
    this.carregarDados(0, 6);

  }

 async carregarDados(pageIndex: number, pageSize: number) {

   await this.service.obterPaginado(pageIndex, pageSize).then(dados => { this.paginador = dados; this.exibir() }, (error) => { console.log(error) });

  }

  private exibir(): void {
    this.list = this.paginador.lista;
  }

  confirmaExcluir(item: ClienteView): void {

    let dialogRef = this.dialog.open(ConfirmaExclusaoComponent, { width: 'auto', data: { nome: item.nome } });
    dialogRef.afterClosed().subscribe((result) => { this.excluir(result, item.id) });
  }

 private async excluir(result: any, id: number) {
    if (result !== "true") return;
   await this.service.excluir(id).then((result) => { this.carregarDados(this.paginator.pageIndex, this.paginator.pageSize) }, (err) => { });//.subscribe();
  }

  ngAfterViewInit(): void {
    this.paginator.page.pipe(tap(() => this.carregarDados(this.paginator.pageIndex, this.paginator.pageSize))).subscribe();
  }

}
