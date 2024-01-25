
using Microsoft.EntityFrameworkCore;

public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly GestaoProdutoDbContext _dbContext;
    public ProdutoRepositorio(GestaoProdutoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task EditarAsync(ProdutoEntidade produtoEntidade)
    {
        _dbContext.Update(produtoEntidade);
        return _dbContext.SaveChangesAsync();
    }

    public Task IncluirAsync(ProdutoEntidade produtoEntidade)
    {
        _dbContext.AddAsync(produtoEntidade);
        return _dbContext.SaveChangesAsync();
    }

    public async Task<List<ProdutoEntidade>> ListarRegitrosPaginadosAsync(ProdutoListarPaginadoDTO listarProdutos)
    {
        IQueryable<ProdutoEntidade> dbFiltro = _dbContext.Produtos.AsNoTracking();
        int paginaAtual = 1;
        int registrosPorPagina = 5;

        if (listarProdutos.Codigo.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.Codigo == listarProdutos.Codigo);
        }

        if (listarProdutos.Ativo.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.Ativo == listarProdutos.Ativo);
        }

        if (listarProdutos.DtFabricacaoDe.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.DtFabricacao >= listarProdutos.DtFabricacaoDe);
        }


        if (listarProdutos.DtFabricacaoAte.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.DtFabricacao <= listarProdutos.DtFabricacaoAte);
        }

        if (listarProdutos.DtValidadeDe.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.DtValidade >= listarProdutos.DtValidadeDe);
        }


        if (listarProdutos.DtValidadeAte.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.DtValidade <= listarProdutos.DtValidadeAte);
        }

        if (listarProdutos.CodigoFornecedor.HasValue)
        {
            dbFiltro = dbFiltro.Where(x => x.CodigoFornecedor == listarProdutos.CodigoFornecedor);
        }

        if (!String.IsNullOrEmpty(listarProdutos.CnpjFornecedor))
        {
            dbFiltro = dbFiltro.Where(x => x.CnpjFornecedor == listarProdutos.CnpjFornecedor);
        }

        if(listarProdutos.Pagina.HasValue && listarProdutos.Pagina > 0)
        {
            paginaAtual = listarProdutos.Pagina.Value;
        }
        if (listarProdutos.RegistrosPorPagina.HasValue && listarProdutos.RegistrosPorPagina > 0)
        {
            registrosPorPagina = listarProdutos.RegistrosPorPagina.Value;
        }

        int paginacao = (paginaAtual - 1) * registrosPorPagina;

        return await dbFiltro.Skip(paginacao).Take(registrosPorPagina).ToListAsync();

    }

    public async Task<ProdutoEntidade?> RetornarPorCodigoAsync(int codigo)
    {
        return await _dbContext.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);

    }
}

