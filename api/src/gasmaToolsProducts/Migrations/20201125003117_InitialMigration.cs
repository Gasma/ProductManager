using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gasmaToolsProducts.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<string>(type: "varchar(50)", nullable: false),
                    UrlPhoto = table.Column<string>(type: "varchar(255)", nullable: true),
                    PhotoPublicId = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreationTime = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
