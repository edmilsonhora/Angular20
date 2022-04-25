import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ClienteView } from '../../../models/cliente-view';
import { ClientesPesquisaComponent } from '../../clientes/clientes-pesquisa/clientes-pesquisa.component';

@Component({
  selector: 'app-pedidos-edit',
  templateUrl: './pedidos-edit.component.html',
  styleUrls: ['./pedidos-edit.component.css']
})
export class PedidosEditComponent implements OnInit {

  cliente: ClienteView = new ClienteView();
  constructor(public dialog:MatDialog) { }

  ngOnInit(): void {
  }

  openDialog(): void {
    let dialogRef = this.dialog.open(ClientesPesquisaComponent, { width: 'auto', data: {} });
    dialogRef.afterClosed().subscribe((result) => {this.fecharDialogo(result) });
  }

  private fecharDialogo(result:any): void {

    if (result === undefined || result === null) return;

    this.cliente = result;

  }

}
