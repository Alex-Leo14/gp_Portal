using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gp_Portal.Infrastructure.Persistence.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosLineas_Lineas_lineaId",
                table: "ServiciosLineas");

            migrationBuilder.DropColumn(
                name: "IdLinea",
                table: "ServiciosLineas");

            migrationBuilder.RenameColumn(
                name: "lineaId",
                table: "ServiciosLineas",
                newName: "LineaId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiciosLineas_lineaId",
                table: "ServiciosLineas",
                newName: "IX_ServiciosLineas_LineaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosLineas_Lineas_LineaId",
                table: "ServiciosLineas",
                column: "LineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosLineas_Lineas_LineaId",
                table: "ServiciosLineas");

            migrationBuilder.RenameColumn(
                name: "LineaId",
                table: "ServiciosLineas",
                newName: "lineaId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiciosLineas_LineaId",
                table: "ServiciosLineas",
                newName: "IX_ServiciosLineas_lineaId");

            migrationBuilder.AddColumn<int>(
                name: "IdLinea",
                table: "ServiciosLineas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiciosLineas_Lineas_lineaId",
                table: "ServiciosLineas",
                column: "lineaId",
                principalTable: "Lineas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
