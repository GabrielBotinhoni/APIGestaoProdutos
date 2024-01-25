﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIGestaoProdutos.Infra.Migrations
{
    [DbContext(typeof(GestaoProdutoDbContext))]
    partial class GestaoProdutoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProdutoEntidade", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CODIGO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<string>("CnpjFornecedor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CNPJ_FORNECEDOR");

                    b.Property<int?>("CodigoFornecedor")
                        .HasColumnType("int")
                        .HasColumnName("CODIGO_FORNECEDOR");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("DescricaoFornecedor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO_FORNECEDOR");

                    b.Property<DateTime?>("DtFabricacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_FABRICACAO");

                    b.Property<DateTime?>("DtValidade")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_VALIDADE");

                    b.HasKey("Codigo");

                    b.ToTable("TB_PRODUTO", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}