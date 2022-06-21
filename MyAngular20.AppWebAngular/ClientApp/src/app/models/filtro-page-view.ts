export class FiltroPageView {


  constructor(pageIndex: number, pageSize: number, sort: string, campo: string) {

    this.pageIndex = pageIndex;
    this.pageSize = pageSize;
    this.sort = sort;
    this.campo = campo;

  }

  pageIndex: number = 0;
  pageSize: number = 0;
  sort: string = "";
  campo: string = "";

}
