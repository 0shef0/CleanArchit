using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchit.Infrastructure.Data.Migrations
{
    public partial class Migrations_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Students");
        }
    }
}
