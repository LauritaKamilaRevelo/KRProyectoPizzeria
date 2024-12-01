using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KRProyectoPizzeria.Migrations
{
    /// <inheritdoc />
    public partial class KRProyectoPizzeria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KRPizzeria",
                columns: table => new
                {
                    idKRPizzeria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KR_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KR_WithCocaCola = table.Column<bool>(type: "bit", nullable: false),
                    KR_Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KRPizzeria", x => x.idKRPizzeria);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KRPizzeria");
        }
    }
}
