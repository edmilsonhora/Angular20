import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { GuardGuard } from './guard.guard';
import { LoginComponent } from './login/login.component';
import { ConfiguracoesEditComponent } from './main/admin/configuracoes-edit/configuracoes-edit.component';
import { ConfiguracoesListComponent } from './main/admin/configuracoes-list/configuracoes-list.component';
import { BimestresEditComponent } from './main/bimestres/bimestres-edit/bimestres-edit.component';
import { BimestresListComponent } from './main/bimestres/bimestres-list/bimestres-list.component';
import { CategoriasEditComponent } from './main/categorias/categorias-edit/categorias-edit.component';
import { CategoriasListComponent } from './main/categorias/categorias-list/categorias-list.component';
import { ClientesEditComponent } from './main/clientes/clientes-edit/clientes-edit.component';
import { ClientesListComponent } from './main/clientes/clientes-list/clientes-list.component';
import { CursosEditComponent } from './main/cursos/cursos-edit/cursos-edit.component';
import { CursosListComponent } from './main/cursos/cursos-list/cursos-list.component';
import { HomeComponent } from './main/home/home/home.component';
import { MainComponent } from './main/main.component';
import { MateriasEditComponent } from './main/materias/materias-edit/materias-edit.component';
import { MateriasListComponent } from './main/materias/materias-list/materias-list.component';
import { NotificacoesComponent } from './main/notificacoes/notificacoes.component';
import { PedidosDetailsComponent } from './main/pedidos/pedidos-details/pedidos-details.component';
import { PedidosEditComponent } from './main/pedidos/pedidos-edit/pedidos-edit.component';
import { PedidosListComponent } from './main/pedidos/pedidos-list/pedidos-list.component';
import { ProdutosEditComponent } from './main/produtos/produtos-edit/produtos-edit.component';
import { ProdutosListComponent } from './main/produtos/produtos-list/produtos-list.component';
import { ProfessoresEditComponent } from './main/professores/professores-edit/professores-edit.component';
import { ProfessoresListComponent } from './main/professores/professores-list/professores-list.component';
import { TurmasEditComponent } from './main/turmas/turmas-edit/turmas-edit.component';
import { TurmasListComponent } from './main/turmas/turmas-list/turmas-list.component';
import { UnidadesEditComponent } from './main/unidades/unidades-edit/unidades-edit.component';
import { UnidadesListComponent } from './main/unidades/unidades-list/unidades-list.component';
import { UsuariosEditComponent } from './main/usuarios/usuarios-edit/usuarios-edit.component';
import { UsuariosListComponent } from './main/usuarios/usuarios-list/usuarios-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: "full" },
  { path: '', component: AppComponent, children: [{path: 'login', component:LoginComponent}] },

  {
    path: 'main', component: MainComponent, children: [
      { path: 'home', component: HomeComponent, canActivate: [GuardGuard] },
      { path: 'notificacoes', component: NotificacoesComponent, canActivate: [GuardGuard] },
      { path: 'clientes', children: [{ path: 'list', component: ClientesListComponent }, { path: 'edit/:id', component: ClientesEditComponent }], canActivate: [GuardGuard] },
      { path: 'usuarios', children: [{ path: 'list', component: UsuariosListComponent }, { path: 'edit/:id', component: UsuariosEditComponent }], canActivate: [GuardGuard] },
      { path: 'produtos', children: [{ path: 'list', component: ProdutosListComponent }, { path: 'edit/:id', component: ProdutosEditComponent }], canActivate: [GuardGuard] },
      { path: 'categorias', children: [{ path: 'list', component: CategoriasListComponent }, { path: 'edit/:id', component: CategoriasEditComponent }], canActivate: [GuardGuard] },
      { path: 'pedidos', children: [{ path: 'list', component: PedidosListComponent }, { path: 'edit/:id', component: PedidosEditComponent }, { path: 'details/:id', component: PedidosDetailsComponent }], canActivate: [GuardGuard] },
      { path: 'configuracoes', children: [{ path: 'list', component: ConfiguracoesListComponent }, { path: 'edit/:id', component: ConfiguracoesEditComponent }], canActivate: [GuardGuard] },
      { path: 'unidades', children: [{ path: 'list', component: UnidadesListComponent }, { path: 'edit/:id', component: UnidadesEditComponent }], canActivate: [GuardGuard] },
      { path: 'cursos', children: [{ path: 'list', component: CursosListComponent }, { path: 'edit/:id', component: CursosEditComponent }], canActivate: [GuardGuard] },
      { path: 'bimestres', children: [{ path: 'list', component: BimestresListComponent }, { path: 'edit/:id', component: BimestresEditComponent }], canActivate: [GuardGuard] },
      { path: 'materias', children: [{ path: 'list', component: MateriasListComponent }, { path: 'edit/:id', component: MateriasEditComponent }], canActivate: [GuardGuard] },
      { path: 'turmas', children: [{ path: 'list', component: TurmasListComponent }, { path: 'edit/:id', component: TurmasEditComponent }], canActivate: [GuardGuard] },
      { path: 'professores', children: [{ path: 'list', component: ProfessoresListComponent }, { path: 'edit/:id', component: ProfessoresEditComponent }], canActivate: [GuardGuard] },

    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
