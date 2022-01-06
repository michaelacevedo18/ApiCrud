using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCrud.Migrations
{
    public partial class migracionini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<long>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Verificado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");
        }
    }
}
