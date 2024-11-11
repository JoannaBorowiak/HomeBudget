using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalkulatorBudzetowy.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kategoria",
                table: "Wydatki");

            migrationBuilder.DropColumn(
                name: "Kategoria",
                table: "Przychody");

            migrationBuilder.AddColumn<int>(
                name: "KategoriaId",
                table: "Wydatki",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategoriaId",
                table: "Przychody",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wydatki_KategoriaId",
                table: "Wydatki",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Przychody_KategoriaId",
                table: "Przychody",
                column: "KategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Przychody_Kategorie_KategoriaId",
                table: "Przychody",
                column: "KategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wydatki_Kategorie_KategoriaId",
                table: "Wydatki",
                column: "KategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Przychody_Kategorie_KategoriaId",
                table: "Przychody");

            migrationBuilder.DropForeignKey(
                name: "FK_Wydatki_Kategorie_KategoriaId",
                table: "Wydatki");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropIndex(
                name: "IX_Wydatki_KategoriaId",
                table: "Wydatki");

            migrationBuilder.DropIndex(
                name: "IX_Przychody_KategoriaId",
                table: "Przychody");

            migrationBuilder.DropColumn(
                name: "KategoriaId",
                table: "Wydatki");

            migrationBuilder.DropColumn(
                name: "KategoriaId",
                table: "Przychody");

            migrationBuilder.AddColumn<string>(
                name: "Kategoria",
                table: "Wydatki",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kategoria",
                table: "Przychody",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
