import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';

import { ClientesListComponent } from './clientes/clientes-list/clientes-list.component';
import { ClientesEditComponent } from './clientes/clientes-edit/clientes-edit.component';
import { CategoriasListComponent } from './categorias/categorias-list/categorias-list.component';
import { CategoriasEditComponent } from './categorias/categorias-edit/categorias-edit.component';
import { ProdutosListComponent } from './produtos/produtos-list/produtos-list.component';
import { ProdutosEditComponent } from './produtos/produtos-edit/produtos-edit.component';
import { PedidosListComponent } from './pedidos/pedidos-list/pedidos-list.component';
import { PedidosDetailsComponent } from './pedidos/pedidos-details/pedidos-details.component';
import { PedidosEditComponent } from './pedidos/pedidos-edit/pedidos-edit.component';
import { UsuariosListComponent } from './usuarios/usuarios-list/usuarios-list.component';
import { UsuariosEditComponent } from './usuarios/usuarios-edit/usuarios-edit.component';
import { HomeComponent } from './home/home/home.component';
import { ConfiguracoesListComponent } from './admin/configuracoes-list/configuracoes-list.component';
import { ConfiguracoesEditComponent } from './admin/configuracoes-edit/configuracoes-edit.component';
import { AvisosComponent } from './avisos/avisos.component';
import { ListaVaziaComponent } from './utils/lista-vazia/lista-vazia.component';
import { MainComponent } from './main.component';
import { AppMaterialModule } from '../app-material.module';
import { FormsModule } from '@angular/forms';
import { MessageboxComponent } from './utils/messagebox/messagebox.component';
import { NotificacoesComponent } from './notificacoes/notificacoes.component';
import { UnidadesListComponent } from './unidades/unidades-list/unidades-list.component';
import { UnidadesEditComponent } from './unidades/unidades-edit/unidades-edit.component';
import { ConfirmaExclusaoComponent } from './utils/confirma-exclusao/confirma-exclusao.component';
import { ClientesPesquisaComponent } from './clientes/clientes-pesquisa/clientes-pesquisa.component';
import { ProdutosPesquisaComponent } from './produtos/produtos-pesquisa/produtos-pesquisa.component';
import { AlunosListComponent } from './alunos/alunos-list/alunos-list.component';
import { AlunosEditComponent } from './alunos/alunos-edit/alunos-edit.component';





@NgModule({
  declarations: [
    MainComponent,
    ClientesListComponent,
    ClientesEditComponent,
    CategoriasListComponent,
    CategoriasEditComponent,
    ProdutosListComponent,
    ProdutosEditComponent,
    PedidosListComponent,
    PedidosDetailsComponent,
    PedidosEditComponent,
    UsuariosListComponent,
    UsuariosEditComponent,
    HomeComponent,
    ConfiguracoesListComponent,
    ConfiguracoesEditComponent,
    AvisosComponent,
    ListaVaziaComponent,
    MessageboxComponent,
    NotificacoesComponent,
    UnidadesListComponent,
    UnidadesEditComponent,
    ConfirmaExclusaoComponent,
    ClientesPesquisaComponent,
    ProdutosPesquisaComponent,
    AlunosListComponent,
    AlunosEditComponent,
  ],
  entryComponents:[MessageboxComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    AppMaterialModule,
    FormsModule,
  ],
  exports:[AvisosComponent]
})
export class MainModule { }
