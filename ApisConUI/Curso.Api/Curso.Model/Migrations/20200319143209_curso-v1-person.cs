using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.Model.Migrations
{
    public partial class cursov1person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    DNI = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SurName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.DNI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
