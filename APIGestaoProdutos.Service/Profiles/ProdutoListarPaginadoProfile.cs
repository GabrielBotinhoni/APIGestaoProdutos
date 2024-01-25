using AutoMapper;

public class ProdutoListarPaginadoProfile : Profile
{
    public ProdutoListarPaginadoProfile()
    {
        CreateMap<ProdutoListarPaginadoModel, ProdutoListarPaginadoDTO>()
            .ForMember(x => x.Codigo, p => p.MapFrom(x => x.Codigo))
            .ForMember(x => x.Ativo, p => p.MapFrom(x => x.Ativo))
            .ForMember(x => x.DtFabricacaoDe, p => p.MapFrom(x => x.DtFabricacaoDe))
            .ForMember(x => x.DtFabricacaoAte, p => p.MapFrom(x => x.DtFabricacaoAte))
            .ForMember(x => x.DtValidadeDe, p => p.MapFrom(x => x.DtValidadeDe))
            .ForMember(x => x.DtValidadeAte, p => p.MapFrom(x => x.DtValidadeAte))
            .ForMember(x => x.CodigoFornecedor, p => p.MapFrom(x => x.CodigoFornecedor))
            .ForMember(x => x.CnpjFornecedor, p => p.MapFrom(x => x.CnpjFornecedor))
            .ForMember(x => x.Pagina, p => p.MapFrom(x => x.Pagina))
            .ForMember(x => x.RegistrosPorPagina, p => p.MapFrom(x => x.RegistrosPorPagina));
    }
}