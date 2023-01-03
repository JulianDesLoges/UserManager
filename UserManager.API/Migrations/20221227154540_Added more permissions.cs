using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManager.API.Migrations
{
    /// <inheritdoc />
    public partial class Addedmorepermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContributePermission",
                table: "UserGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CreatePermission",
                table: "UserGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ManagePermission",
                table: "UserGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContributePermission",
                table: "UserGroup");

            migrationBuilder.DropColumn(
                name: "CreatePermission",
                table: "UserGroup");

            migrationBuilder.DropColumn(
                name: "ManagePermission",
                table: "UserGroup");
        }
    }
}
