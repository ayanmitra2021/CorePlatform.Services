using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorePlatform.Services.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuditColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "RuleLibrary");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "RuleLibrary");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "RuleLibrary");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "RuleLibrary");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "PlanAssociation");

            migrationBuilder.DropColumn(
                name: "createdDate",
                table: "PlanAssociation");

            migrationBuilder.DropColumn(
                name: "modifiedBy",
                table: "PlanAssociation");

            migrationBuilder.DropColumn(
                name: "modifiedDate",
                table: "PlanAssociation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "RuleLibrary",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdDate",
                table: "RuleLibrary",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "RuleLibrary",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modifiedDate",
                table: "RuleLibrary",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "PlanAssociation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdDate",
                table: "PlanAssociation",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "modifiedBy",
                table: "PlanAssociation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "modifiedDate",
                table: "PlanAssociation",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
