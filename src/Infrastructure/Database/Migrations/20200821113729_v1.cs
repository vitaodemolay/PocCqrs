using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCustomer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TbContact",
                columns: table => new
                {
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 250, nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbContact", x => new { x.CustomerId, x.Type, x.Value });
                    table.ForeignKey(
                        name: "FK_TbContact_TbCustomer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TbCustomer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbContact");

            migrationBuilder.DropTable(
                name: "TbCustomer");
        }
    }
}
