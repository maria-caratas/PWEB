using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication8.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Istorice",
                table: "Istorice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizatori",
                table: "Utilizatori");

            migrationBuilder.RenameTable(
                name: "Utilizatori",
                newName: "Utilizator");

            migrationBuilder.AddColumn<int>(
                name: "IstoricRezultateRezultatQuizzId",
                table: "RezultatQuizz",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IstoricRezultateUtilizatorId",
                table: "RezultatQuizz",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Istorice",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NumeUtilizator",
                table: "Utilizator",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Istorice",
                table: "Istorice",
                columns: new[] { "UtilizatorId", "RezultatQuizzId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizator",
                table: "Utilizator",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatQuizz_IstoricRezultateUtilizatorId_IstoricRezultate~",
                table: "RezultatQuizz",
                columns: new[] { "IstoricRezultateUtilizatorId", "IstoricRezultateRezultatQuizzId" });

            migrationBuilder.CreateIndex(
                name: "IX_Utilizator_Rol",
                table: "Utilizator",
                column: "Rol",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Istorice_Utilizator_UtilizatorId",
                table: "Istorice",
                column: "UtilizatorId",
                principalTable: "Utilizator",
                principalColumn: "UtilizatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RezultatQuizz_Istorice_IstoricRezultateUtilizatorId_Istoric~",
                table: "RezultatQuizz",
                columns: new[] { "IstoricRezultateUtilizatorId", "IstoricRezultateRezultatQuizzId" },
                principalTable: "Istorice",
                principalColumns: new[] { "UtilizatorId", "RezultatQuizzId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Istorice_Utilizator_UtilizatorId",
                table: "Istorice");

            migrationBuilder.DropForeignKey(
                name: "FK_RezultatQuizz_Istorice_IstoricRezultateUtilizatorId_Istoric~",
                table: "RezultatQuizz");

            migrationBuilder.DropIndex(
                name: "IX_RezultatQuizz_IstoricRezultateUtilizatorId_IstoricRezultate~",
                table: "RezultatQuizz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Istorice",
                table: "Istorice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizator",
                table: "Utilizator");

            migrationBuilder.DropIndex(
                name: "IX_Utilizator_Rol",
                table: "Utilizator");

            migrationBuilder.DropColumn(
                name: "IstoricRezultateRezultatQuizzId",
                table: "RezultatQuizz");

            migrationBuilder.DropColumn(
                name: "IstoricRezultateUtilizatorId",
                table: "RezultatQuizz");

            migrationBuilder.RenameTable(
                name: "Utilizator",
                newName: "Utilizatori");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Istorice",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NumeUtilizator",
                table: "Utilizatori",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Istorice",
                table: "Istorice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizatori",
                table: "Utilizatori",
                column: "UtilizatorId");
        }
    }
}
