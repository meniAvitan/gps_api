using Microsoft.EntityFrameworkCore.Migrations;

namespace mySqlConnectionDemo.Migrations
{
    public partial class l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Location",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<ulong>(
                name: "IsActive",
                table: "Location",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Location",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
