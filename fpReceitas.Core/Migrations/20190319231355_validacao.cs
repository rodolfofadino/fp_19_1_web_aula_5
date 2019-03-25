using Microsoft.EntityFrameworkCore.Migrations;

namespace fpReceitas.Core.Migrations
{
    public partial class validacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update receitas set nome ='teste' where nome is null");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Receitas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Receitas",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
