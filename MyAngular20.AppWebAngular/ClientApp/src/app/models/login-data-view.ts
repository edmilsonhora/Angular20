export class LoginDataView {

  usuario: string = "";
  senha: string = "";
  manterLogado: boolean = false;

  validar(): void {

    let regrasQuebradas = "";

    if (this.senha === "")
      regrasQuebradas += "O campo Senha é obrigatório.;";

    if (this.usuario === "")
      regrasQuebradas += "O campo Usuário é obrigatório.;";

    if (regrasQuebradas.length > 0)
      throw new Error(regrasQuebradas);
  }

}
