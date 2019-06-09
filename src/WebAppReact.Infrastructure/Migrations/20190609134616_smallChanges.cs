using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppReact.Infrastructure.Migrations
{
    public partial class smallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "Reviews");

            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
