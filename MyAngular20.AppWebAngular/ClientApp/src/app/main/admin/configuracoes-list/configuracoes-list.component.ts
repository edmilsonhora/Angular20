import { Component, OnInit } from '@angular/core';
import { ConfiguracaoView } from '../../../models/configuracao-view';

@Component({
  selector: 'app-configuracoes-list',
  templateUrl: './configuracoes-list.component.html',
  styleUrls: ['./configuracoes-list.component.css']
})
export class ConfiguracoesListComponent implements OnInit {
  configuracoes: ConfiguracaoView[] = [];
  colunas = ["edit", "nome", "cadastradoPor", "dataCadastro", "del"];

  constructor() { }

  ngOnInit(): void {
  }

}
