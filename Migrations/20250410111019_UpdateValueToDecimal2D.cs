using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace phibra_back_end.Migrations
{
    /// <inheritdoc />
    public partial class UpdateValueToDecimal2D : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""EntryInfos""
                ALTER COLUMN ""Value"" TYPE decimal(10,2)
                USING ""Value""::decimal(10,2);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""EntryInfos""
                ALTER COLUMN ""Value"" TYPE TEXT
                USING ""Value""::text;
            ");
        }

    }
}
