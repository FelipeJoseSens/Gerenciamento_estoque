using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConFinServer.Migrations
{
    /// <inheritdoc />
    public partial class CidadeEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Cidade",
                newName: "EstadoSigla");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoSigla",
                table: "Cidade",
                column: "EstadoSigla");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estado_EstadoSigla",
                table: "Cidade",
                column: "EstadoSigla",
                principalTable: "Estado",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_EstadoSigla",
                table: "Cidade");

            migrationBuilder.DropIndex(
                name: "IX_Cidade_EstadoSigla",
                table: "Cidade");

            migrationBuilder.RenameColumn(
                name: "EstadoSigla",
                table: "Cidade",
                newName: "Estado");
        }
    }
}
