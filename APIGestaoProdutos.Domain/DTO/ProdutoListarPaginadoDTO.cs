public class ProdutoListarPaginadoDTO
{
    public int? Codigo { get; set; }
    public bool? Ativo { get; set; }
    public DateTime? DtFabricacaoDe { get; set; }
    public DateTime? DtFabricacaoAte { get; set; }
    public DateTime? DtValidadeDe { get; set; }
    public DateTime? DtValidadeAte { get; set; }
    public int? CodigoFornecedor { get; set; }
    public string? CnpjFornecedor { get; set; }
    public int? Pagina { get; set; }
    public int? RegistrosPorPagina { get; set; }
}

