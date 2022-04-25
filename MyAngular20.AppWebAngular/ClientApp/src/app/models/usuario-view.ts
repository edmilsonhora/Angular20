export class UsuarioView {
  id: number = 0;
  nomeCompleto: string = "";
  usuarioNome: string = "";
  email: string = "";
  perfil: string = "";
  notificacoes: number = 0;
  senha: string = "";
  confirmaSenha: string = "";
  dtUltimoLogin: string = "";
  ativo: boolean = true;
  ativoStr: string = "";

  dataCadastro: string = "";
  cadastradoPor: string = "";
  dataAtualizacao: string = "";
  atualizadoPor: string = "";

  constructor() { }

  validar(): void {

    let regrasQuebradas: string = "";
    this.atualizadoPor = sessionStorage["nomeUsuario"];

    if (this.nomeCompleto === "")
      regrasQuebradas += "O campo Nome Completo é obrigatório.;";
    if (this.usuarioNome === "")
      regrasQuebradas += "O campo Nome Usuário é obrigatório.;";
    if (this.email === "")
      regrasQuebradas += "O campo Email é obrigatório.;";
    if (this.perfil === "")
      regrasQuebradas += "O campo Perfil é obrigatório.;";
    if (this.atualizadoPor === "")
      regrasQuebradas += "O campo Atualizado Por é obrigatório.;";
    if (this.senha !== this.confirmaSenha)
      regrasQuebradas != "Senha e Confirma Senha não conferem.;";

    if (this.id === 0) {
      if (this.senha === "")
        regrasQuebradas += "O campo Senha é obrigatório.;";
      if (this.confirmaSenha === "")
        regrasQuebradas += "O campo Confirma Senha é obrigatório.;";
    }

   

    if (regrasQuebradas.length > 0)
      throw new Error(regrasQuebradas);
    

  }


}
