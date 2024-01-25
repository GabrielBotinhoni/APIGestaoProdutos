

using FluentValidation.TestHelper;
using NUnit.Framework;

namespace APIGestaoProdutos.Testes.Application
{
    public class ProdutoIncluirModelValidatorTest
    {
        [Test]
        public void IncluirProdutoSemDescricaoDeveRetornarErro()
        {
            var produtoIncluirModel = new ProdutoIncluirModel()
            {
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(-1),
                DtValidade = DateTime.Now.AddMonths(1),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor ",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoIncluirModelValidator();
            var resultado = validator.TestValidate(produtoIncluirModel);
            resultado.ShouldHaveValidationErrorFor(x => x.Descricao);
        }

        [Test]
        public void IncluirProdutoComFabricacaoMaiorQueValidadeDeveRetornarErro()
        {
            var produtoIncluirModel = new ProdutoIncluirModel()
            {
                Descricao = "Espelho",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(3),
                DtValidade = DateTime.Now.AddMonths(1),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 2",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoIncluirModelValidator();
            var resultado = validator.TestValidate(produtoIncluirModel);
            resultado.ShouldHaveValidationErrorFor(x => x.DtValidade);
        }

        [Test]
        public void IncluirProdutoComFabricacaoIgualAValidadeDeveRetornarErro()
        {
            var produtoIncluirModel = new ProdutoIncluirModel()
            {
                Descricao = "Espelho",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(1).Date,
                DtValidade = DateTime.Now.AddMonths(1).Date,
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 2",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoIncluirModelValidator();
            var resultado = validator.TestValidate(produtoIncluirModel);
            resultado.ShouldHaveValidationErrorFor(x => x.DtValidade);
        }

        [Test]
        public void IncluirProdutoComCNPJInvalidoDeveRetornarErro()
        {
            var produtoIncluirModel = new ProdutoIncluirModel()
            {
                Descricao = "Espelho",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(-3),
                DtValidade = DateTime.Now.AddMonths(1),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 2",
                CnpjFornecedor = "12.123.123/00010-01"
            };
            var validator = new ProdutoIncluirModelValidator();
            var resultado = validator.TestValidate(produtoIncluirModel);
            resultado.ShouldHaveValidationErrorFor(x => x.CnpjFornecedor);
        }

        [Test]
        public void IncluirProdutoValidoDeveRetornarSucesso()
        {
            var produtoIncluirModel = new ProdutoIncluirModel()
            {
                Descricao = "Espelho",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(-3),
                DtValidade = DateTime.Now.AddMonths(1),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 2",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoIncluirModelValidator();
            var resultado = validator.TestValidate(produtoIncluirModel);
            resultado.ShouldNotHaveAnyValidationErrors();
        }
    }
}
