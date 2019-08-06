using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LazyCMS.Migrations
{
    public partial class LazyCMS_Dev_v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LazyCMS_WxUser",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LazyCMS_WxUser");
        }
    }
}
