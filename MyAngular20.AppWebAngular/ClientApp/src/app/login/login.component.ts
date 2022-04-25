import { AfterViewInit } from '@angular/core';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDataView } from '../models/login-data-view';
import { LoginService } from '../services/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {

  showLoader: boolean = false;
  loginData: LoginDataView = new LoginDataView();
  erros: string[] = [];  

  @ViewChild("myinput") myInputField: ElementRef | undefined;

  constructor(private service:LoginService, private router:Router) { }
    

  ngOnInit(): void {

    if (localStorage["manterLogado"] !== undefined) {
      sessionStorage["nomeUsuario"] = localStorage["nomeUsuario"];
      this.service.estaAutenticado = true;
      this.router.navigateByUrl('/main/home');
    }

  }

  ngAfterViewInit(): void {
    this.myInputField?.nativeElement.focus();
  }

  autenticar(): void {
    this.showLoader = true;
    try {
      this.erros = [];
      this.loginData.validar();
      this.service.autenticar(this.loginData).subscribe((result) => { this.service.estaAutenticado = result },
        (err) => { this.trataErro(err) },
        () => this.router.navigateByUrl('/main/home'));
     
      
    } catch (e: any) {
      this.showLoader = false;
      this.erros = e.message.slice(0, -1).split(';');
    }
  }

  trataErro(erro: any) {

    this.erros[0] = erro.error;
    this.showLoader = false;
  }

}
