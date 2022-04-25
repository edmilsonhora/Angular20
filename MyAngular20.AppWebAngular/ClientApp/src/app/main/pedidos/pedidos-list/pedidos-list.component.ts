import { Component, OnInit } from '@angular/core';
import { PedidoView } from '../../../models/pedido-view';

@Component({
  selector: 'app-pedidos-list',
  templateUrl: './pedidos-list.component.html',
  styleUrls: ['./pedidos-list.component.css']
})
export class PedidosListComponent implements OnInit {

  pedidos: PedidoView[] = [];
  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];
  constructor() { }

  ngOnInit(): void {
  }

}
