using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaslowApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospedes",
                columns: table => new
                {
                    HospedeID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospedes", x => x.HospedeID);
                });

            migrationBuilder.CreateTable(
                name: "TiposQuarto",
                columns: table => new
                {
                    TipoQuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposQuarto", x => x.TipoQuartoID);
                });

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    QuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroQuarto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PrecoPorNoite = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TipoQuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.QuartoID);
                    table.ForeignKey(
                        name: "FK_Quartos_TiposQuarto_TipoQuartoID",
                        column: x => x.TipoQuartoID,
                        principalTable: "TiposQuarto",
                        principalColumn: "TipoQuartoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HospedeID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuartoID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reservas_Hospedes_HospedeID",
                        column: x => x.HospedeID,
                        principalTable: "Hospedes",
                        principalColumn: "HospedeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Quartos_QuartoID",
                        column: x => x.QuartoID,
                        principalTable: "Quartos",
                        principalColumn: "QuartoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ReservaID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoID);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Reservas_ReservaID",
                        column: x => x.ReservaID,
                        principalTable: "Reservas",
                        principalColumn: "ReservaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ReservaID",
                table: "Pagamentos",
                column: "ReservaID");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_TipoQuartoID",
                table: "Quartos",
                column: "TipoQuartoID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HospedeID",
                table: "Reservas",
                column: "HospedeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_QuartoID",
                table: "Reservas",
                column: "QuartoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Hospedes");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "TiposQuarto");
        }
    }
}
