using AutoMapper;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepositorio _produtoRepositorio;
    private readonly IMapper _mapper;
    public ProdutoService(IProdutoRepositorio produtoRepositorio, IMapper mapper)
    {

        _produtoRepositorio = produtoRepositorio;
        _mapper = mapper;

    }

    public async Task DeletarAsync(int codigo)
    {
        var produtoCadastrado = await RetornarProdutoCadastradoAsync(codigo);

        produtoCadastrado.Ativo = false;

        await _produtoRepositorio.EditarAsync(produtoCadastrado);
    }

    public async Task EditarAsync(ProdutoEditarModel produtoEntidade)
    {
        var produtoCadastrado = await RetornarProdutoCadastradoAsync(produtoEntidade.Codigo);

        produtoCadastrado.Descricao = produtoEntidade.Descricao ?? produtoCadastrado.Descricao;
        produtoCadastrado.DtValidade = produtoEntidade.DtValidade ?? produtoCadastrado.DtValidade;
        produtoCadastrado.DtFabricacao = produtoEntidade.DtFabricacao ?? produtoCadastrado.DtFabricacao;
        produtoCadastrado.CodigoFornecedor = produtoEntidade.CodigoFornecedor ?? produtoCadastrado.CodigoFornecedor;
        produtoCadastrado.DescricaoFornecedor = produtoEntidade.DescricaoFornecedor ?? produtoCadastrado.DescricaoFornecedor;
        produtoCadastrado.CnpjFornecedor = produtoEntidade.CnpjFornecedor ?? produtoCadastrado.CnpjFornecedor;

        await  _produtoRepositorio.EditarAsync(produtoCadastrado);
    }

    public Task IncluirAsync(ProdutoIncluirModel model)
    {
        var produtoEntidade = _mapper.Map<ProdutoEntidade>(model);

        return _produtoRepositorio.IncluirAsync(produtoEntidade);
    }

    public async Task<List<ProdutoDTO>> ListarRegitrosPaginadosAsync(ProdutoListarPaginadoModel model)
    {
        var produtoListarPaginado = _mapper.Map<ProdutoListarPaginadoEntidade>(model);

        var produtosPaginados =  await _produtoRepositorio.ListarRegitrosPaginadosAsync(produtoListarPaginado);

        return _mapper.Map<List<ProdutoDTO>>(produtosPaginados);
    }

    public async Task<ProdutoDTO> RetornarPorCodigoAsync(int codigo)
    {
        if (codigo <= 0)
            throw new NotImplementedException();

        var produtoEntidade = await _produtoRepositorio.RetornarPorCodigoAsync(codigo);

        return _mapper.Map<ProdutoDTO>(produtoEntidade);
    }

    private async Task<ProdutoEntidade> RetornarProdutoCadastradoAsync(int codigoProduto)
    {
        if (codigoProduto <= 0)
            throw new Exception("O Código do produto deve ser maior que 0");
        var produtoCadastrado = await _produtoRepositorio.RetornarPorCodigoAsync(codigoProduto);

        if (produtoCadastrado == null)
            throw new Exception("O Código do produto não foi econtrado");

        return produtoCadastrado;
    }

}

