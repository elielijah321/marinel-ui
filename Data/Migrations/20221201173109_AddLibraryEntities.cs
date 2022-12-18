using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marinel.Migrations
{
    /// <inheritdoc />
    public partial class AddLibraryEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryBookRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryBookId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    RentedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpextedReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBookRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryBookRentals_LibraryBooks_LibraryBookId",
                        column: x => x.LibraryBookId,
                        principalTable: "LibraryBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryBookRentals_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBookRentals_LibraryBookId",
                table: "LibraryBookRentals",
                column: "LibraryBookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBookRentals_StudentId",
                table: "LibraryBookRentals",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryBookRentals");

            migrationBuilder.DropTable(
                name: "LibraryBooks");
        }
    }
}
