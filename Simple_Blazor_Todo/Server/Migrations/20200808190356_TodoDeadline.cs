using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simple_Blazor_Todo.Server.Migrations
{
    public partial class TodoDeadline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "TodoItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadLine",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneAt",
                table: "TodoItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadLine",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "DoneAt",
                table: "TodoItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "TodoItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
