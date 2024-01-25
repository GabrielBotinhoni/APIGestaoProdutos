
public interface IProdutoRepositorio
{
    Task IncluirAsync(ProdutoEntidade produtoEntidade);
    Task EditarAsync(ProdutoEntidade produtoEntidade);
    Task<ProdutoEntidade?> RetornarPorCodigoAsync(int codigo);
    Task<List<ProdutoEntidade>> ListarRegitrosPaginadosAsync(ProdutoListarPaginadoEntidade listarProdutos);
}

