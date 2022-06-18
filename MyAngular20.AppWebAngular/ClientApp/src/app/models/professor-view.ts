export class ProfessorView {
  constructor() { }

  id: number = 0;
  nome: string = "";
  materiasIds: string[] = [];
  cadastradoPor: string = "";
  dataCadastro: string = "";
  atualizadoPor: string = "";
  dataAtualizacao: string = "";

  validar(): void {

    let regrasQuebradas: string = "";

    this.atualizadoPor = sessionStorage["nomeUsuario"];

    if (this.nome === "")
      regrasQuebradas += "O campo nome é obrigatório.;";

    if (this.materiasIds.length < 1)
      regrasQuebradas += "Informe pelo menos uma matéria.;";

    if (this.atualizadoPor === "")
      regrasQuebradas += "O campo atualizado por é obrigatório.;";

    if (regrasQuebradas.length > 0)
      throw new Error(regrasQuebradas);

  }
}
