using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM_SqLite.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Personas");
        }
    }
}
