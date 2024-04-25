using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication8.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CapitolInvatare",
                columns: table => new
                {
                    CapitolInvatareId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titlu = table.Column<string>(type: "text", nullable: false),
                    Continut = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitolInvatare", x => x.CapitolInvatareId);
                });

            migrationBuilder.CreateTable(
                name: "IntrebariQuizz",
                columns: table => new
                {
                    IntrebareId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextIntrebare = table.Column<string>(type: "text", nullable: false),
                    OptiuniRaspuns = table.Column<string[]>(type: "text[]", nullable: false),
                    RaspunsCorect = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntrebariQuizz", x => x.IntrebareId);
                });

            migrationBuilder.CreateTable(
                name: "Istorice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UtilizatorId = table.Column<int>(type: "integer", nullable: false),
                    RezultatQuizzId = table.Column<int>(type: "integer", nullable: false),
                    Scor = table.Column<int>(type: "integer", nullable: false),
                    DataRezultat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Istorice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RezultatQuizz",
                columns: table => new
                {
                    RezultatQuizzId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UtilizatorId = table.Column<int>(type: "integer", nullable: false),
                    IntrebareId = table.Column<int>(type: "integer", nullable: false),
                    ScorObtinut = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezultatQuizz", x => x.RezultatQuizzId);
                });

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    UtilizatorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeUtilizator = table.Column<string>(type: "text", nullable: false),
                    Parola = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.UtilizatorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapitolInvatare");

            migrationBuilder.DropTable(
                name: "IntrebariQuizz");

            migrationBuilder.DropTable(
                name: "Istorice");

            migrationBuilder.DropTable(
                name: "RezultatQuizz");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
