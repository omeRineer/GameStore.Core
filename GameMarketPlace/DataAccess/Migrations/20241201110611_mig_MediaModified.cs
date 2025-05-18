using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_MediaModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaPath",
                table: "Medias",
                newName: "Node");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Medias",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "Node",
                table: "Medias",
                newName: "MediaPath");
        }
    }
}
