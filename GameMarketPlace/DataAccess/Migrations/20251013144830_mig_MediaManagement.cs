using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_MediaManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "ProcessGroups",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "SliderContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameImages_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameImages_GameId",
                table: "GameImages",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameImages");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "SliderContents");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistributorId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_TypeLookups_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeLookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProcessGroups",
                columns: new[] { "Id", "Code", "CreateDate", "Description", "EditDate" },
                values: new object[] { 100, "MEDIATYPE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MediaType", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "TypeLookups",
                columns: new[] { "Id", "Code", "CreateDate", "Description", "EditDate", "ProcessGroupId" },
                values: new object[,]
                {
                    { 101, "GAMEIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GameImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 102, "SLIDERITEMIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderItemImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 103, "SLIDERSIDEITEMIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderSideItemImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 104, "BLOGCOVERIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BlogCoverImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 105, "GAMECOVERIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GameCoverImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TypeId",
                table: "Medias",
                column: "TypeId");
        }
    }
}
