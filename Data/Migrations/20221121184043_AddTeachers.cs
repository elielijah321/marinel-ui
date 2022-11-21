using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marinel.Migrations
{
    /// <inheritdoc />
    public partial class AddTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ClassId", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, 1, "NATHANIEL ADDY", "" },
                    { 2, 1, "DIVINE ANTWI", "" },
                    { 3, 1, "DENKYI ABIGAIL", "" },
                    { 4, 1, "AKUA ABIGAIL BERKO", "" },
                    { 5, 1, "MINKAH ANITA AKUOKO", "" },
                    { 6, 1, "BOAKYE EMMANUEL", "" },
                    { 7, 1, "DORIS GYASI", "" },
                    { 8, 1, "NTOW PATIENT", "" },
                    { 9, 1, "ABEVI ERIC", "" },
                    { 10, 1, "MERCY TUTUWAA OSEI", "" },
                    { 11, 1, "SANDRA HARVEY", "" },
                    { 12, 1, "GODWIN QUAMPAH", "" },
                    { 13, 1, "COBBLAH PRISCILLA", "" },
                    { 14, 1, "AMURI DIANA", "" },
                    { 15, 1, "QUARCOO FELIX", "" },
                    { 16, 1, "BUKARI HAWAWU", "" },
                    { 17, 1, "KUSU PERFECT", "" },
                    { 18, 1, "JOEL DIGBE", "" },
                    { 19, 1, "MILLICENT OBENG", "" },
                    { 20, 1, "VERTINA OWUSU AMPONSAH", "" },
                    { 21, 1, "DELALI TSEKPO", "" },
                    { 22, 1, "WISDOM ADJEI", "" },
                    { 23, 1, "FRANCIS OFOSU", "" },
                    { 24, 1, "GYEBI BAAH", "" },
                    { 25, 1, "BOADI ASARE CHARITY", "" },
                    { 26, 1, "GEORGINA OSEI", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassId",
                table: "Teachers",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
