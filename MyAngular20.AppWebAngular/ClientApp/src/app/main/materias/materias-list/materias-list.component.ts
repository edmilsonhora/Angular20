import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { tap } from 'rxjs';
import { FiltroPageView } from '../../../models/filtro-page-view';
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

  erros: string[] = [];
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  paginador!: PaginadorListas<MateriaView[]>;

  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];
  list: MateriaView[] = [];
  filtro!: FiltroPageView;

 

  constructor(private service: MateriasService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.paginador = { lista: [], totalRegistros: 0 };
    this.filtro = new FiltroPageView(this.paginator?.pageIndex ?? 0, this.paginator?.pageSize ?? 6, "asc", "");
    this.carregarDados(this.filtro);

  }

  carregarDados(filtro: FiltroPageView) {

    this.service.obterPaginadoPor(filtro).pipe(tap(dados => { this.paginador = dados })).subscribe((result) => { this.exibir() });

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
    this.filtro = new FiltroPageView(this.paginator.pageIndex, this.paginator.pageSize, this.sort.direction, this.sort.active);
    this.service.excluir(id).subscribe((result) => { }, (err) => { this.erros = err.error.slice(0, -1).split(';') }, () => { this.carregarDados(this.filtro) });
  }

  ngAfterViewInit(): void {

    this.sort.sortChange.pipe(tap(() => this.carregarDados(new FiltroPageView(this.paginator.pageIndex, this.paginator.pageSize, this.sort.direction, this.sort.active)))).subscribe();
    this.paginator.page.pipe(tap(() => this.carregarDados(new FiltroPageView(this.paginator.pageIndex, this.paginator.pageSize, this.sort.direction, this.sort.active)))).subscribe();
  }

}
