using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expect.Timeslots.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companys_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    PlatformId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gates_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanySchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaxTaskCount = table.Column<int>(type: "integer", nullable: false),
                    DayOfWeeks = table.Column<int[]>(type: "integer[]", nullable: false),
                    From = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    To = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TaskTypes = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanySchedules_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GateSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GateId = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeeks = table.Column<int[]>(type: "integer[]", nullable: false),
                    From = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    To = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TaskTypes = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GateSchedules_Gates_GateId",
                        column: x => x.GateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timeslots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    From = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    To = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    GateId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timeslots_Gates_GateId",
                        column: x => x.GateId,
                        principalTable: "Gates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companys_PlatformId",
                table: "Companys",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySchedules_CompanyId",
                table: "CompanySchedules",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_PlatformId",
                table: "Gates",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GateSchedules_GateId",
                table: "GateSchedules",
                column: "GateId");

            migrationBuilder.CreateIndex(
                name: "IX_Timeslots_GateId",
                table: "Timeslots",
                column: "GateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanySchedules");

            migrationBuilder.DropTable(
                name: "GateSchedules");

            migrationBuilder.DropTable(
                name: "Timeslots");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
