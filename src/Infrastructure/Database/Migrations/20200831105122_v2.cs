using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Database.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TbCustomer",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOrder",
                table: "TbCustomer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "TbCustomer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "LastOrder",
                table: "TbCustomer");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "TbCustomer");
        }
    }
}
