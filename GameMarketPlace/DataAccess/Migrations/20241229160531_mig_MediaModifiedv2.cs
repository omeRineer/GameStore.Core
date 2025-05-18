using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_MediaModifiedv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TypeLookups_MediaTypeId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "MediaTypeId",
                table: "Medias",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_MediaTypeId",
                table: "Medias",
                newName: "IX_Medias_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TypeLookups_TypeId",
                table: "Medias",
                column: "TypeId",
                principalTable: "TypeLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_TypeLookups_TypeId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Medias",
                newName: "MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_TypeId",
                table: "Medias",
                newName: "IX_Medias_MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_TypeLookups_MediaTypeId",
                table: "Medias",
                column: "MediaTypeId",
                principalTable: "TypeLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
