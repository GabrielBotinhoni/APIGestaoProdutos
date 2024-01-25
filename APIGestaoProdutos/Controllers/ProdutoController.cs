using Microsoft.AspNetCore.Mvc;

namespace APIGestaoProdutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(ProdutoIncluirModel model)
        {
            await _produtoService.IncluirAsync(model);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Editar(ProdutoEditarModel model)
        {
            await _produtoService.EditarAsync(model);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> RetornarPorCodigo(int codigo)
        {
            var produtoDTO = await _produtoService.RetornarPorCodigoAsync(codigo);

            return Ok(produtoDTO);
        }
        [HttpPut("Deletar")]

        public async Task<IActionResult> Deletar(int codigo)
        {
            await _produtoService.DeletarAsync(codigo);

            return NoContent();
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarPaginados([FromQuery]ProdutoListarPaginadoModel produtoListar)
        {
            var produtosListados = await _produtoService.ListarRegitrosPaginadosAsync(produtoListar);

            return Ok(produtosListados);
        }
    }
}