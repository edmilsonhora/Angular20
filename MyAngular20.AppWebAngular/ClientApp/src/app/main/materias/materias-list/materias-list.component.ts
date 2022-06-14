import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { tap } from 'rxjs';
import { MateriaView } from '../../../models/materia-view';
import { PaginadorListas } from '../../../models/paginador-listas';
import { MateriasService } from '../../../services/materias.service';
import { ConfirmaExclusaoComponent } from '../../utils/confirma-exclusao/confirma-exclusao.component';

@Component({
  selector: 'app-materias-list',
  templateUrl: './materias-list.component.html',
  styleUrls: ['./materias-list.component.css']
})
export class MateriasListComponent implements OnInit, AfterViewInit {

  paginador!: PaginadorListas<MateriaView[]>;
  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];
  list: MateriaView[] = [];

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private service: MateriasService, private dialog: MatDialog) { }

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

  confirmaExcluir(item: MateriaView): void {

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
