
using AutoMapper;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ProdutoIncluirModel, ProdutoEntidade>()
            .ForMember(x => x.Descricao, p => p.MapFrom(x => x.Descricao))
            .ForMember(x => x.Ativo, p => p.MapFrom(x => x.Ativo))
            .ForMember(x => x.DtFabricacao, p => p.MapFrom(x => x.DtFabricacao))
            .ForMember(x => x.DtValidade, p => p.MapFrom(x => x.DtValidade))
            .ForMember(x => x.CodigoFornecedor, p => p.MapFrom(x => x.CodigoFornecedor))
            .ForMember(x => x.DescricaoFornecedor, p => p.MapFrom(x => x.DescricaoFornecedor))
            .ForMember(x => x.CnpjFornecedor, p => p.MapFrom(x => x.CnpjFornecedor));

        CreateMap<ProdutoEntidade, ProdutoDTO>()
            .ForMember(x => x.Codigo, p => p.MapFrom(x => x.Codigo))
            .ForMember(x => x.Descricao, p => p.MapFrom(x => x.Descricao))
            .ForMember(x => x.Ativo, p => p.MapFrom(x => x.Ativo))
            .ForMember(x => x.DtFabricacao, p => p.MapFrom(x => x.DtFabricacao))
            .ForMember(x => x.DtValidade, p => p.MapFrom(x => x.DtValidade))
            .ForMember(x => x.CodigoFornecedor, p => p.MapFrom(x => x.CodigoFornecedor))
            .ForMember(x => x.DescricaoFornecedor, p => p.MapFrom(x => x.DescricaoFornecedor))
            .ForMember(x => x.CnpjFornecedor, p => p.MapFrom(x => x.CnpjFornecedor));
    }
}

