using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveEasee.Migrations
{
    public partial class AddautheticationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "pagamento",
                type: "float",
                unicode: false,
                maxLength: 45,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "valor",
                table: "pagamento",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldUnicode: false,
                oldMaxLength: 45);
        }
    }
}
