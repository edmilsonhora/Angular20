import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ClienteView } from '../../../models/cliente-view';
import { ClientesService } from '../../../services/clientes.service';


@Component({
  selector: 'app-clientes-pesquisa',
  templateUrl: './clientes-pesquisa.component.html',
  styleUrls: ['./clientes-pesquisa.component.css']
})
export class ClientesPesquisaComponent implements OnInit {

  list: ClienteView[] = [];
  item: ClienteView= new ClienteView();
  constructor(public dialogRef: MatDialogRef<ClientesPesquisaComponent>, private service : ClientesService) { }

  ngOnInit(): void {
  }

  pesquisar(event: any): void {
    this.list = [];
    if (this.item.nome.length > 1) {
      this.service.obterPorNome(this.item.nome).subscribe((result) => { this.list = result }, (err) => { });
    };
  }

  //seleciona(): void {
  //  this.dialogRef.close({ selectedItem: this.item });
  //}

}
