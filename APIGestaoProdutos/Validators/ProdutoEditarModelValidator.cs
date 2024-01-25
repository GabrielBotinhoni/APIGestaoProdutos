
using FluentValidation;

public class ProdutoEditarModelValidator: AbstractValidator<ProdutoEditarModel>
{
    public ProdutoEditarModelValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty().WithMessage("O Código do produto deve ser informado");
        RuleFor(x => x.Codigo).GreaterThan(0).WithMessage("O Código do produto deve ser maior que 0");
        RuleFor(x => x.DtValidade)
            .GreaterThan(x => x.DtFabricacao)
            .WithMessage("A data de fabriacação do produto deve ser menor que a data de validade.");
        RuleFor(x => x.CnpjFornecedor).Must((cnpj) =>
        {
            return ValidacaoUtil.ValidaMascaraCNPJ(cnpj);
        }).WithMessage("O cnpj informado deve estar no formato 'XX.XXX.XXX/XXXX-XX'");
    }

}

