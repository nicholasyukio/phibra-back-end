using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace phibra_back_end.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemperatureC",
                table: "EntryInfos",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "EntryInfos",
                newName: "User");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "EntryInfos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "EntryInfos");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "EntryInfos",
                newName: "TemperatureC");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "EntryInfos",
                newName: "Summary");
        }
    }
}
