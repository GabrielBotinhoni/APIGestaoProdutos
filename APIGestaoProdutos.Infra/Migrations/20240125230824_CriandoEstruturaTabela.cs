using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIGestaoProdutos.Infra.Migrations
{
    public partial class CriandoEstruturaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    CODIGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "Varchar(max)", nullable: false),
                    ATIVO = table.Column<bool>(type: "bit", nullable: false),
                    DT_FABRICACAO = table.Column<DateTime>(type: "Datetime", nullable: true),
                    DT_VALIDADE = table.Column<DateTime>(type: "Datetime", nullable: true),
                    CODIGO_FORNECEDOR = table.Column<int>(type: "int", nullable: true),
                    DESCRICAO_FORNECEDOR = table.Column<string>(type: "Varchar(max)", nullable: true),
                    CNPJ_FORNECEDOR = table.Column<string>(type: "Varchar(18)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.CODIGO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUTO");
        }
    }
}
