using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseAngular.Data.Migrations
{
    public partial class AuditInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cats",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyOn",
                table: "Cats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "ModifyBy",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyOn",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "ModifyOn",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifyBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifyOn",
                table: "AspNetUsers");
        }
    }
}
