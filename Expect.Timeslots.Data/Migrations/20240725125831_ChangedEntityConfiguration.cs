using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expect.Timeslots.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntityConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companys_Platforms_PlatformId",
                table: "Companys");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySchedules_Companys_CompanyId",
                table: "CompanySchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companys",
                table: "Companys");

            migrationBuilder.RenameTable(
                name: "Companys",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Companys_PlatformId",
                table: "Companies",
                newName: "IX_Companies_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Platforms_PlatformId",
                table: "Companies",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySchedules_Companies_CompanyId",
                table: "CompanySchedules",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Platforms_PlatformId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanySchedules_Companies_CompanyId",
                table: "CompanySchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Companys");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_PlatformId",
                table: "Companys",
                newName: "IX_Companys_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companys",
                table: "Companys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companys_Platforms_PlatformId",
                table: "Companys",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanySchedules_Companys_CompanyId",
                table: "CompanySchedules",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
