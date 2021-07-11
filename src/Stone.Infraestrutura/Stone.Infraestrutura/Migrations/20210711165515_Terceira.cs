using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stone.Infraestrutura.Migrations
{
    public partial class Terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Validade",
                table: "Cartoes",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4)");

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("8311aa92-5ae9-4175-9b9d-c1e53d56315f"), "App1", 35m });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("57b2318b-56eb-4ea2-9727-91775513e806"), "App2", 12.5m });

            migrationBuilder.InsertData(
                table: "Aplicativos",
                columns: new[] { "Id", "Nome", "Valor" },
                values: new object[] { new Guid("8d914d5a-cb7e-4259-a01d-87f1ac49a3e3"), "App3", 7.8m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("57b2318b-56eb-4ea2-9727-91775513e806"));

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("8311aa92-5ae9-4175-9b9d-c1e53d56315f"));

            migrationBuilder.DeleteData(
                table: "Aplicativos",
                keyColumn: "Id",
                keyValue: new Guid("8d914d5a-cb7e-4259-a01d-87f1ac49a3e3"));

            migrationBuilder.AlterColumn<string>(
                name: "Validade",
                table: "Cartoes",
                type: "varchar(4)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

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
        }
    }
}
