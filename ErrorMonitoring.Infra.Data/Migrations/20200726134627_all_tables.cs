using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorMonitoring.Infra.Data.Migrations
{
    public partial class all_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENVIRONMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    envName = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENVIRONMENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EVENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eStatus = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    eLevel = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    eOrigin = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    eDate = table.Column<DateTime>(type: "date", nullable: false),
                    eMessage = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    eDescription = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    eException = table.Column<string>(unicode: false, nullable: true),
                    eColectedBy = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EVENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pName = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IsMobile = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsWeb = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsDesktop = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOGS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project = table.Column<int>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    Archived = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK__LOGS__EventType__3C69FB99",
                        column: x => x.EventType,
                        principalTable: "EVENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LOGS__Project__3B75D760",
                        column: x => x.Project,
                        principalTable: "PROJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROJECTS_ENVIRONMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project = table.Column<int>(nullable: false),
                    Environment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJECTS_ENVIRONMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK__PROJECTS___Envir__412EB0B6",
                        column: x => x.Environment,
                        principalTable: "ENVIRONMENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__PROJECTS___Proje__403A8C7D",
                        column: x => x.Project,
                        principalTable: "PROJECTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOGS_EventType",
                table: "LOGS",
                column: "EventType");

            migrationBuilder.CreateIndex(
                name: "IX_LOGS_Project",
                table: "LOGS",
                column: "Project");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_ENVIRONMENTS_Environment",
                table: "PROJECTS_ENVIRONMENTS",
                column: "Environment");

            migrationBuilder.CreateIndex(
                name: "IX_PROJECTS_ENVIRONMENTS_Project",
                table: "PROJECTS_ENVIRONMENTS",
                column: "Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGS");

            migrationBuilder.DropTable(
                name: "PROJECTS_ENVIRONMENTS");

            migrationBuilder.DropTable(
                name: "EVENTS");

            migrationBuilder.DropTable(
                name: "ENVIRONMENTS");

            migrationBuilder.DropTable(
                name: "PROJECTS");
        }
    }
}
