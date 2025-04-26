using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrubaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: false),
                    Cantidad = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descripcion = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTO");
        }
    }
}
