using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // AdminNavbar tablosunu oluştur
            migrationBuilder.CreateTable(
                name: "AdminNavbar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false, defaultValue: 7),
                    Turn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminNavbar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminNavbar_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // NavbarMain tablosunu oluştur
            migrationBuilder.CreateTable(
                name: "NavbarMain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isMainMenu = table.Column<bool>(type: "bit", nullable: false),
                    isTopMenu = table.Column<bool>(type: "bit", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false, defaultValue: 7),
                    Turn = table.Column<int>(type: "int", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    SeoURL = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarMain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavbarMain_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Index ekle (performans için)
            migrationBuilder.CreateIndex(
                name: "IX_AdminNavbar_LanguageId",
                table: "AdminNavbar",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NavbarMain_LanguageId",
                table: "NavbarMain",
                column: "LanguageId");

            // Daha önceki sabit veri güncellemesi
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "LanguageId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "LanguageId",
                value: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Geri alma işlemleri
            migrationBuilder.DropTable(
                name: "AdminNavbar");

            migrationBuilder.DropTable(
                name: "NavbarMain");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "LanguageId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "LanguageId",
                value: 1);
        }
    }
}
