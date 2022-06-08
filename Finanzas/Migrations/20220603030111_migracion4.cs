using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzas.Migrations
{
    public partial class migracion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "transaccion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "transaccion");
        }
    }
}
