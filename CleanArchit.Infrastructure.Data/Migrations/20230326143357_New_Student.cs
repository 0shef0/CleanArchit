using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchit.Infrastructure.Data.Migrations
{
    public partial class New_Student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "Students",
                newName: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Students",
                newName: "Rank");
        }
    }
}
