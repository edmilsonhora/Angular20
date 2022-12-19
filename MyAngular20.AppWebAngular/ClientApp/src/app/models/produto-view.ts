export class ProdutoView {

  constructor() { }
  id: number = 0;
  codigo: string = "";
  descricao: string = "";
  precoUnitario: number = 0;
  categoriaId: number = 0;
  qtdEmEstoque: number = 0;
  ativo: boolean = true;
  unidadeDeMedidaId: number = 0;
  dataCadastro: string = "";
  cadastradoPor: string = "";
  dataAtualizacao: string = "";
  atualizadoPor: string = "";

  validar(): void {

    let regrasQuebradas: string = "";
    this.atualizadoPor = sessionStorage["nomeUsuario"];

    if (this.codigo === "")
      regrasQuebradas += "O campo Código é obrigatório.;";
    if (this.descricao === "")
      regrasQuebradas += "O campo Descrição é obrigatório.;";
    if (this.categoriaId === 0)
      regrasQuebradas += "O campo Categoria é obrigatório.;";
    if (this.unidadeDeMedidaId === 0)
      regrasQuebradas += "O campo Un. de Medida é obrigatório.;";

    if (this.precoUnitario === 0)
      regrasQuebradas += "O campo Preço Unitário é obrigatório.;";

    if (this.qtdEmEstoque === 0)
      regrasQuebradas += "O campo Qtd. Estoque é obrigatório.;";

    if (this.atualizadoPor === "")
      regrasQuebradas += "O campo Atualizado Por é obrigatório.;";

    if (regrasQuebradas.length > 0)
      throw new Error(regrasQuebradas);

  }
}
