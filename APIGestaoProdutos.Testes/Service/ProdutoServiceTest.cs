

using AutoMapper;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace APIGestaoProdutos.Testes.Service
{
    public class ProdutoServiceTest
    {
        private IProdutoService _produtoService;
        [SetUp]
        public void Setup()
        {
            var mockIProdutoRepositorio = new Mock<IProdutoRepositorio>();
            var mockIMapper = new Mock<IMapper>();
   
            var produtoEntidade = new ProdutoEntidade()
            {
                Codigo = 1,
                Ativo = true,
                Descricao = "Espelho Retrovisor",
                DtValidade = DateTime.Now.AddMonths(4),
                DtFabricacao = DateTime.Now.AddMonths(-3),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "Fornecedor 1",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var listaProduto = new List<ProdutoEntidade>();
            listaProduto.Add(produtoEntidade);

            mockIMapper.Setup(x => x.Map<ProdutoListarPaginadoDTO>(It.Is<ProdutoListarPaginadoModel>(x => x.Ativo == true))).Returns(new ProdutoListarPaginadoDTO() { Ativo = true });

            mockIProdutoRepositorio.Setup(x => x.RetornarPorCodigoAsync(It.Is<int>(x => x == 1))).ReturnsAsync(produtoEntidade);
            mockIProdutoRepositorio.Setup(x => x.ListarRegitrosPaginadosAsync(It.Is<ProdutoListarPaginadoDTO>(x => x.Ativo == true))).ReturnsAsync(listaProduto);

            _produtoService = new ProdutoService(mockIProdutoRepositorio.Object, mockIMapper.Object);
        }

        #region Deletar

        [Test]
        public void DeletarProdutoComCodigoZeradoDeveRetornarErro()
        {
            var ex = Assert.ThrowsAsync<Exception>(() => _produtoService.DeletarAsync(0));

            Assert.NotNull(ex);
            Assert.That(ex.Message, Is.EqualTo("O Código do produto deve ser maior que 0"));
        }

        [Test]
        public void DeletarProdutoInexistenteDeveRetornarErro()
        {
            var ex = Assert.ThrowsAsync<Exception>(() => _produtoService.DeletarAsync(99));

            Assert.NotNull(ex);
            Assert.That(ex.Message, Is.EqualTo("O Código do produto não foi econtrado"));
        }
        [Test]
        public void DeletarProdutoValidoDeveRetornarSucesso()
        {
             Assert.DoesNotThrowAsync(() => _produtoService.DeletarAsync(1));
        }
        #endregion

        #region Editar

        [Test]
        public void EditarProdutoComCodigoZeradoDeveRetornarErro()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 0,
                Descricao = "Espelho",
                DtValidade = DateTime.Now.AddMonths(6),
                DtFabricacao = DateTime.Now.AddMonths(-2),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "Fornecedor 2",
            };

            var ex = Assert.ThrowsAsync<Exception>(() => _produtoService.EditarAsync(produtoEditarModel));

            Assert.NotNull(ex);
            Assert.That(ex.Message, Is.EqualTo("O Código do produto deve ser maior que 0"));
        }
        [Test]
        public void EditarProdutoComCodigoInvalidoDeveRetornarErro()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 99,
                Descricao = "Espelho",
                DtValidade = DateTime.Now.AddMonths(6),
                DtFabricacao = DateTime.Now.AddMonths(-2),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "Fornecedor 2",
            };

            var ex = Assert.ThrowsAsync<Exception>(() => _produtoService.EditarAsync(produtoEditarModel));

            Assert.NotNull(ex);
            Assert.That(ex.Message, Is.EqualTo("O Código do produto não foi econtrado"));
        }

        [Test]
        public void EditarProdutoValidoDeveRetornarSucesso()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 1,
                Descricao = "Espelho",
                DtValidade = DateTime.Now.AddMonths(6),
                DtFabricacao = DateTime.Now.AddMonths(-2),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "Fornecedor 2",
            };

            Assert.DoesNotThrowAsync(() => _produtoService.EditarAsync(produtoEditarModel));
        }
        #endregion

        #region Incluir
        [Test]
        public void IncluirProdutoValidoDeveRetornarSucesso()
        {
            var produtoIncluirModel = new ProdutoIncluirModel()
            {
                Ativo = true,
                Descricao = "Espelho",
                DtValidade = DateTime.Now.AddMonths(6),
                DtFabricacao = DateTime.Now.AddMonths(-2),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "Fornecedor 2",
                CnpjFornecedor = "12.123.123/0001-12"
            };

            Assert.DoesNotThrowAsync(() => _produtoService.IncluirAsync(produtoIncluirModel));
        }
        #endregion

        #region ListarRegitrosPaginados
        [Test]
        public void ListarRegitrosPaginadosValidoDeveRetornarSucesso()
        {
            var produtoListarPaginado = new ProdutoListarPaginadoModel()
            {
                Ativo = true,
            };

            Assert.DoesNotThrowAsync(() => _produtoService.ListarRegitrosPaginadosAsync(produtoListarPaginado));
        }
        #endregion


        #region RetornarPorCodigo
        [Test]
        public void RetornarPorCodigoValidoDeveRetornarSucesso()
        {
            Assert.DoesNotThrowAsync(() => _produtoService.RetornarPorCodigoAsync(1));
        }
        #endregion

    }
}
