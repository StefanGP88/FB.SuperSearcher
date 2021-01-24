using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FB.SuperSearcher.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchTerm = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTerms", x => x.Id);
                    table.UniqueConstraint("AK_SearchTerms_SearchTerm", x => x.SearchTerm);
                });

            migrationBuilder.CreateTable(
                name: "SearchDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SearchTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchDates_SearchTerms_SearchTermId",
                        column: x => x.SearchTermId,
                        principalTable: "SearchTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchTermCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    SearchTermId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchTermCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchTermCharacters_SearchTerms_SearchTermId",
                        column: x => x.SearchTermId,
                        principalTable: "SearchTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchDates_SearchTermId",
                table: "SearchDates",
                column: "SearchTermId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchTermCharacters_SearchTermId",
                table: "SearchTermCharacters",
                column: "SearchTermId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchDates");

            migrationBuilder.DropTable(
                name: "SearchTermCharacters");

            migrationBuilder.DropTable(
                name: "SearchTerms");
        }
    }
}
