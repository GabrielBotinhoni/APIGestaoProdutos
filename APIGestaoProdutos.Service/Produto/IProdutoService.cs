public interface IProdutoService
{

    Task IncluirAsync(ProdutoIncluirModel model);
    Task EditarAsync(ProdutoEditarModel model);
    Task DeletarAsync(int codigo);

    Task<ProdutoDTO> RetornarPorCodigoAsync(int codigo);
    Task<List<ProdutoDTO>> ListarRegitrosPaginadosAsync(ProdutoListarPaginadoModel model);

}
