using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_RemoveRecordState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "UserPermissions");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "TypeLookups");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "SystemRequirements");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "StatusLookups");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "SliderContents");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "ProcessGroups");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "RecordState",
                table: "BackgroundJobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "UserPermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "TypeLookups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "SystemRequirements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "StatusLookups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "SliderContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "RolePermissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "ProcessGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Menus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Medias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecordState",
                table: "BackgroundJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
