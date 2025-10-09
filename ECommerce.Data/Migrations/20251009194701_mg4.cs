using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class mg4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Sliders",
                type: "int",
             nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Products",
                type: "int",
               nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ProductImages",
                type: "int",
               nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Orders",
                type: "int",
               nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "OrderLines",
                type: "int",
              nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "News",
                type: "int",
               nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Contacts",
                type: "int",
               nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "CompanyInfos",
                type: "int",
               nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Categories",
                type: "int",
              nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Brands",
                type: "int",
               nullable: false,
                  defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Addresses",
                type: "int",
              nullable: false,
                  defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavigationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_LanguageId",
                table: "Sliders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LanguageId",
                table: "Products",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_LanguageId",
                table: "ProductImages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanguageId",
                table: "Orders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_LanguageId",
                table: "OrderLines",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_News_LanguageId",
                table: "News",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfos_LanguageId",
                table: "CompanyInfos",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LanguageId",
                table: "Categories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_LanguageId",
                table: "Brands",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LanguageId",
                table: "Addresses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_LanguageId",
                table: "Resources",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Languages_LanguageId",
                table: "Addresses",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Languages_LanguageId",
                table: "Brands",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                table: "Categories",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfos_Languages_LanguageId",
                table: "CompanyInfos",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Languages_LanguageId",
                table: "Contacts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Languages_LanguageId",
                table: "News",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Languages_LanguageId",
                table: "OrderLines",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Languages_LanguageId",
                table: "Orders",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Languages_LanguageId",
                table: "ProductImages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sliders_Languages_LanguageId",
                table: "Sliders",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Languages_LanguageId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Languages_LanguageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfos_Languages_LanguageId",
                table: "CompanyInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Languages_LanguageId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Languages_LanguageId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Languages_LanguageId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Languages_LanguageId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Languages_LanguageId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Languages_LanguageId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sliders_Languages_LanguageId",
                table: "Sliders");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(name: "IX_Sliders_LanguageId", table: "Sliders");
            migrationBuilder.DropIndex(name: "IX_Products_LanguageId", table: "Products");
            migrationBuilder.DropIndex(name: "IX_ProductImages_LanguageId", table: "ProductImages");
            migrationBuilder.DropIndex(name: "IX_Orders_LanguageId", table: "Orders");
            migrationBuilder.DropIndex(name: "IX_OrderLines_LanguageId", table: "OrderLines");
            migrationBuilder.DropIndex(name: "IX_News_LanguageId", table: "News");
            migrationBuilder.DropIndex(name: "IX_Contacts_LanguageId", table: "Contacts");
            migrationBuilder.DropIndex(name: "IX_CompanyInfos_LanguageId", table: "CompanyInfos");
            migrationBuilder.DropIndex(name: "IX_Categories_LanguageId", table: "Categories");
            migrationBuilder.DropIndex(name: "IX_Brands_LanguageId", table: "Brands");
            migrationBuilder.DropIndex(name: "IX_Addresses_LanguageId", table: "Addresses");

            migrationBuilder.DropColumn(name: "LanguageId", table: "Sliders");
            migrationBuilder.DropColumn(name: "LanguageId", table: "Products");
            migrationBuilder.DropColumn(name: "LanguageId", table: "ProductImages");
            migrationBuilder.DropColumn(name: "LanguageId", table: "Orders");
            migrationBuilder.DropColumn(name: "LanguageId", table: "OrderLines");
            migrationBuilder.DropColumn(name: "LanguageId", table: "News");
            migrationBuilder.DropColumn(name: "LanguageId", table: "Contacts");
            migrationBuilder.DropColumn(name: "LanguageId", table: "CompanyInfos");
            migrationBuilder.DropColumn(name: "LanguageId", table: "Categories");
            migrationBuilder.DropColumn(name: "LanguageId", table: "Brands");
            migrationBuilder.DropColumn(name: "LanguageId", table: "Addresses");
        }
    }
}
