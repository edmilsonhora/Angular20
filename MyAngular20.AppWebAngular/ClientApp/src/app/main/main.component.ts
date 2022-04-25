import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { UsuarioView } from '../models/usuario-view';
import { LoginService } from '../services/login.service';
import { UsuariosService } from '../services/usuarios.service';
import { MessageboxComponent } from './utils/messagebox/messagebox.component';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit, AfterViewInit {

  usuario: UsuarioView = new UsuarioView();

  constructor(private service: LoginService, private router:Router, private usuarioService: UsuariosService, private dialog : MatDialog) { }


  ngAfterViewInit(): void {
    
    }

  ngOnInit(): void {

    this.usuarioService.obterUsuario().subscribe((result) => { this.usuario = result });

  }

  openDialog() {

    let dialogRef = this.dialog.open(MessageboxComponent);
    dialogRef.afterClosed().subscribe((result) => { this.logoff(result) });

  }

 private logoff(resultado:string) {

   if (resultado !== "true") return;

    sessionStorage.clear();
    localStorage.clear();
    this.service.estaAutenticado = false;
    this.router.navigate(['/login']);
    
  }

}
