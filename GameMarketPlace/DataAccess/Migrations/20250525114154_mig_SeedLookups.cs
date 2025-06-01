using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_SeedLookups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProcessGroups",
                columns: new[] { "Id", "Code", "CreateDate", "Description", "EditDate" },
                values: new object[,]
                {
                    { 100, "MEDIATYPE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MediaType", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 200, "SLIDERTYPE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderType", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 300, "NOTIFICATIONTYPE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NotificationType", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 400, "LOGTYPE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LogType", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TypeLookups",
                columns: new[] { "Id", "Code", "CreateDate", "Description", "EditDate", "ProcessGroupId" },
                values: new object[,]
                {
                    { 101, "GAMEIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GameImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 102, "SLIDERITEMIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderItemImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 103, "SLIDERSIDEITEMIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderSideItemImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 104, "BLOGCOVERIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BlogCoverImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 105, "GAMECOVERIMAGE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GameCoverImage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 201, "SLIDERITEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderItem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { 202, "SLIDERSIDEITEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SliderSideItem", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { 401, "DEBUG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debug", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400 },
                    { 402, "CONSOLE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Console", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400 },
                    { 403, "NOTIFICATION", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notification", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400 },
                    { 404, "DATABASE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DataBase", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400 },
                    { 405, "FILE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "File", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 400 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProcessGroups",
                keyColumn: "Id",
                keyValue: 300);

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
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "TypeLookups",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "ProcessGroups",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "ProcessGroups",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "ProcessGroups",
                keyColumn: "Id",
                keyValue: 400);
        }
    }
}
