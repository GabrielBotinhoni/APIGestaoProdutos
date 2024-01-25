
using FluentValidation;
using System.Text.RegularExpressions;

public class ProdutoIncluirModelValidator : AbstractValidator<ProdutoIncluirModel>
{
    public ProdutoIncluirModelValidator()
    {
        RuleFor(x => x.Descricao).NotEmpty()
            .WithMessage("A descrição do produto deve ser informada");
        RuleFor(x => x.DtValidade)
            .GreaterThan(x => x.DtFabricacao)
            .WithMessage("A data de fabricação do produto deve ser menor que a data de validade.");
        RuleFor(x => x.CnpjFornecedor).Must((cnpj) =>
        {
            return ValidacaoUtil.ValidaMascaraCNPJ(cnpj);
        }).WithMessage("O cnpj informado deve estar no formato 'XX.XXX.XXX/XXXX-XX'");
    }
}

