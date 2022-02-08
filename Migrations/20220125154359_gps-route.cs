using Microsoft.EntityFrameworkCore.Migrations;

namespace mySqlConnectionDemo.Migrations
{
    public partial class gpsroute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Location");
        }
    }
}
