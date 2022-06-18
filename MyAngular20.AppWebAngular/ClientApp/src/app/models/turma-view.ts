export class TurmaView {
  constructor() { }

  id: number = 0;
  nome: string = "";
  ano: string = "";
  cursoId: number = 0;
  curso: string = "";
  limite: number = 0;
  qtdAtual: string = "";
  cadastradoPor: string = "";
  dataCadastro: string = "";
  atualizadoPor: string = "";
  dataAtualizacao: string = "";

  validar(): void {

    let regrasQuebradas: string = "";

    this.atualizadoPor = sessionStorage["nomeUsuario"];

    if (this.nome === "")
      regrasQuebradas += "O campo nome é obrigatório.;";

    if (this.cursoId === 0)
      regrasQuebradas += "O campo curso é obrigatório.;";

    if (this.limite === 0)
      regrasQuebradas += "O campo limite é obrigatório.;";

    if (this.ano === "")
      regrasQuebradas += "O campo ano é obrigatório.;";

    if (this.atualizadoPor === "")
      regrasQuebradas += "O campo atualizado por é obrigatório.;";

    if (regrasQuebradas.length > 0)
      throw new Error(regrasQuebradas);
  }
}
