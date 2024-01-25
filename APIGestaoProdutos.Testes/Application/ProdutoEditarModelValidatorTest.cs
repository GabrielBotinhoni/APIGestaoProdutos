using FluentValidation.TestHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGestaoProdutos.Testes.Application
{
    public class ProdutoEditarModelValidatorTest
    {
        [Test]
        public void EditarProdutoSemCodigoDeveRetornarErro()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Descricao = "Porta de vidro",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(-1),
                DtValidade = DateTime.Now.AddMonths(1),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 1",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoEditarModelValidator();
            var resultado = validator.TestValidate(produtoEditarModel);
            resultado.ShouldHaveValidationErrorFor(x => x.Codigo);
        }


        [Test]
        public void EditarProdutoComDataFabricacaoMaiorQueValidadeDeveRetornarErro()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 1,
                Descricao = "Porta de vidro",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(2),
                DtValidade = DateTime.Now.AddMonths(1),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 1",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoEditarModelValidator();
            var resultado = validator.TestValidate(produtoEditarModel);
            resultado.ShouldHaveValidationErrorFor(x => x.DtValidade);
        }

        [Test]
        public void EditarProdutoComDataFabricacaoIgualAValidadeDeveRetornarErro()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 1,
                Descricao = "Porta de vidro",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(1).Date,
                DtValidade = DateTime.Now.AddMonths(1).Date,
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 1",
                CnpjFornecedor = "12.123.123/0001-01"
            };
            var validator = new ProdutoEditarModelValidator();
            var resultado = validator.TestValidate(produtoEditarModel);
            resultado.ShouldHaveValidationErrorFor(x => x.DtValidade);
        }

        [Test]
        public void EditarProdutoComCNPJFornecedorInvalidoDeveRetornarErro()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 1,
                Descricao = "Porta de vidro",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(-1),
                DtValidade = DateTime.Now.AddMonths(3),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 1",
                CnpjFornecedor = "X1.123.123/0001-01"
            };
            var validator = new ProdutoEditarModelValidator();
            var resultado = validator.TestValidate(produtoEditarModel);
            resultado.ShouldHaveValidationErrorFor(x => x.CnpjFornecedor);
        }

        [Test]
        public void EditarProdutoValidoDeveRetornarSucesso()
        {
            var produtoEditarModel = new ProdutoEditarModel()
            {
                Codigo = 1,
                Descricao = "Porta de vidro",
                Ativo = true,
                DtFabricacao = DateTime.Now.AddMonths(-1),
                DtValidade = DateTime.Now.AddMonths(3),
                CodigoFornecedor = 123,
                DescricaoFornecedor = "Fornecedor 1",
                CnpjFornecedor = "01.123.123/0001-01"
            };
            var validator = new ProdutoEditarModelValidator();
            var resultado = validator.TestValidate(produtoEditarModel);
            resultado.ShouldNotHaveAnyValidationErrors();
        }
    }
}
