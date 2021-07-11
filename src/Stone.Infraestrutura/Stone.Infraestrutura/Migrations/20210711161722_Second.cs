using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infraestrutura.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartoes_AspNetUsers_IdUsuario",
                table: "Cartoes");

            migrationBuilder.DropIndex(
                name: "IX_Cartoes_IdUsuario",
                table: "Cartoes");

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("29c521dc-0db0-4432-8481-4beef403822e"));

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("5c87ddda-fcbf-4eee-b396-035c200eb239"));

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("9e2c2e76-3811-4ab9-b85a-2601341844c8"));

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Cartoes");

            migrationBuilder.AddColumn<int>(
                name: "StatusDaTransacao",
                table: "Transacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsuarioCartao",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCartao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCartao", x => new { x.IdCartao, x.IdUsuario });
                    table.ForeignKey(
                        name: "FK_UsuarioCartao_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioCartao_Cartoes_IdCartao",
                        column: x => x.IdCartao,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("281969eb-7fc6-4914-8340-6cff41b1af1e"), "App1", 35m });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("5ddf4c0a-ee5e-4970-86ce-25891ea7e643"), "App2", 12.5m });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("d20e92b7-e4ed-4a84-9e2c-24b3fa47f741"), "App3", 7.8m });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCartao_IdUsuario",
                table: "UsuarioCartao",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioCartao");

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("281969eb-7fc6-4914-8340-6cff41b1af1e"));

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("5ddf4c0a-ee5e-4970-86ce-25891ea7e643"));

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("d20e92b7-e4ed-4a84-9e2c-24b3fa47f741"));

            migrationBuilder.DropColumn(
                name: "StatusDaTransacao",
                table: "Transacao");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Cartoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("9e2c2e76-3811-4ab9-b85a-2601341844c8"), "App1", 35m });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("5c87ddda-fcbf-4eee-b396-035c200eb239"), "App2", 12.5m });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("29c521dc-0db0-4432-8481-4beef403822e"), "App3", 7.8m });

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_IdUsuario",
                table: "Cartoes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartoes_AspNetUsers_IdUsuario",
                table: "Cartoes",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
