
public class ProdutoEntidade
{
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
    public DateTime? DtFabricacao { get; set; }
    public DateTime? DtValidade { get; set; }
    public int? CodigoFornecedor { get; set; }
    public string? DescricaoFornecedor { get; set; }
    public string? CnpjFornecedor { get; set; }
}

