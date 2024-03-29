﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProdutoMapeamento : IEntityTypeConfiguration<ProdutoEntidade>
{

    public void Configure(EntityTypeBuilder<ProdutoEntidade> builder)
    {
        builder.ToTable("TB_PRODUTO");
        builder.HasKey(x => x.Codigo);
        builder.Property(x => x.Codigo).HasColumnName("CODIGO");
        builder.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasColumnType("Varchar(max)");
        builder.Property(x => x.Ativo).HasColumnName("ATIVO");
        builder.Property(x => x.DtFabricacao).HasColumnName("DT_FABRICACAO").HasColumnType("Datetime");
        builder.Property(x => x.DtValidade).HasColumnName("DT_VALIDADE").HasColumnType("Datetime");
        builder.Property(x => x.CodigoFornecedor).HasColumnName("CODIGO_FORNECEDOR");
        builder.Property(x => x.DescricaoFornecedor).HasColumnName("DESCRICAO_FORNECEDOR").HasColumnType("Varchar(max)");
        builder.Property(x => x.CnpjFornecedor).HasColumnName("CNPJ_FORNECEDOR").HasColumnType("Varchar(18)");

    }
}

