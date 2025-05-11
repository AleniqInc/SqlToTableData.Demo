using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Server.Migrations
{
    /// <inheritdoc />
    public partial class sqlite_migration_581 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Elevation = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    Sql = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "ID", "Country", "Elevation", "Name" },
                values: new object[,]
                {
                    { 1L, "Greece", 70, "Athens" },
                    { 2L, "Spain", 0, "Barcelona" },
                    { 3L, "China", 43, "Beijing" },
                    { 4L, "Serbia", 117, "Belgrade" },
                    { 5L, "Brazil", 1172, "Brasília" },
                    { 6L, "Slovakia", 124, "Bratislava" },
                    { 7L, "Romania", 85, "Bucharest" },
                    { 8L, "Argentina", 25, "Buenos Aires" },
                    { 9L, "Mexico", 1140, "Ciudad Juárez" },
                    { 10L, "Romania", 360, "Cluj-Napoca" },
                    { 11L, "Argentina", 352, "Córdoba" },
                    { 12L, "Slovakia", 206, "Košice" },
                    { 13L, "Spain", 650, "Madrid" },
                    { 14L, "Mexico", 2240, "Mexico City" },
                    { 15L, "Russia", 156, "Moscow" },
                    { 16L, "Serbia", 195, "Niš" },
                    { 17L, "Serbia", 80, "Novi Sad" },
                    { 18L, "Greece", 0, "Patras" },
                    { 19L, "Serbia", 450, "Prizren" },
                    { 20L, "Brazil", 0, "Rio de Janeiro" },
                    { 21L, "Argentina", 31, "Rosario" },
                    { 22L, "Russia", 0, "Saint Petersburg" },
                    { 23L, "Brazil", 760, "São Paulo" },
                    { 24L, "China", 0, "Shanghai" },
                    { 25L, "Greece", 0, "Thessaloniki" },
                    { 26L, "Mexico", 20, "Tijuana" },
                    { 27L, "Romania", 90, "Timișoara" },
                    { 28L, "Spain", 0, "Valencia" },
                    { 29L, "Russia", 0, "Vladivostok" },
                    { 30L, "China", 405, "Xi'an" },
                    { 31L, "Slovakia", 378, "Žilina" }
                });

            migrationBuilder.InsertData(
                table: "Query",
                columns: new[] { "ID", "Sql" },
                values: new object[,]
                {
                    { 1L, "SELECT ID, Name, Country, Elevation FROM City" },
                    { 2L, "SELECT ID, Name, Country, Elevation FROM City WHERE Elevation > {0}" },
                    { 3L, "SELECT ID, Name, Country, Elevation FROM City WHERE Elevation BETWEEN {0} AND {1}" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Query");
        }
    }
}
