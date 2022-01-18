using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace mySqlConnectionDemo.Migrations
{
    public partial class lcation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Destination = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Lat = table.Column<float>(type: "float", nullable: false),
                    Lng = table.Column<float>(type: "float", nullable: false),
                    IsActive = table.Column<short>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<byte>(type: "tinyint(3)", nullable: false),
                    Destination = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsPlayer = table.Column<ulong>(type: "bit", nullable: false),
                    Source = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }
    }
}
