using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesListApp.Migrations
{
    public partial class AddedActorsAndCastings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Castings",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castings", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Castings_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Castings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Humphrey", "Bogart" },
                    { 2, "Ingrid", "Bergman" },
                    { 3, "Keanu", "Reeves" },
                    { 4, "Carrie-Anne", "Moss" },
                    { 5, "John", "Travolta" },
                    { 6, "Uma", "Thurman" }
                });

            migrationBuilder.InsertData(
                table: "Castings",
                columns: new[] { "ActorId", "MovieId", "Role" },
                values: new object[,]
                {
                    { 1, 1, "Rick Blaine" },
                    { 2, 1, "Ilsa Lund" },
                    { 3, 2, "Neo" },
                    { 4, 2, "Trinity" },
                    { 5, 3, "Vincet Vega" },
                    { 6, 3, "Mia Wallace" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Castings_MovieId",
                table: "Castings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Castings");

            migrationBuilder.DropTable(
                name: "Actors");
        }
    }
}
