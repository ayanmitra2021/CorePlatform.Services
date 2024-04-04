using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorePlatform.Services.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleLibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuleName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    RuleExpression = table.Column<string>(type: "TEXT", nullable: false),
                    createdDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdBy = table.Column<string>(type: "TEXT", nullable: false),
                    modifiedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleLibrary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanAssociation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlanName = table.Column<string>(type: "TEXT", nullable: false),
                    LibraryId = table.Column<int>(type: "INTEGER", nullable: false),
                    createdDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    createdBy = table.Column<string>(type: "TEXT", nullable: false),
                    modifiedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAssociation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanAssociation_RuleLibrary_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "RuleLibrary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanAssociation_LibraryId",
                table: "PlanAssociation",
                column: "LibraryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanAssociation");

            migrationBuilder.DropTable(
                name: "RuleLibrary");
        }
    }
}
