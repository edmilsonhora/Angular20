namespace MyAngular20.ApplicationService.Views
{
    public class ProdutoFotoView : ViewBase
    {

        public byte[] Bytes { get; set; }
        public string NomeArquivo { get; set; }
        public string Extensao { get; set; }
        public long Tamanho { get; set; }
        public string MymeType { get; set; }
        public bool Principal { get; set; }

    }
}
