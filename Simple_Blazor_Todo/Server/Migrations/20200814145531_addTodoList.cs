using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Simple_Blazor_Todo.Server.Migrations
{
    public partial class addTodoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    TodoListId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titel = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.TodoListId);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    TodoItemID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentListTodoListId = table.Column<int>(nullable: false),
                    Titel = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DoneAt = table.Column<DateTime>(nullable: true),
                    DeadLine = table.Column<DateTime>(nullable: true),
                    TodoItemID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.TodoItemID);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ParentListTodoListId",
                        column: x => x.ParentListTodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "TodoListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoItems_TodoItemID1",
                        column: x => x.TodoItemID1,
                        principalTable: "TodoItems",
                        principalColumn: "TodoItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ParentListTodoListId",
                table: "TodoItems",
                column: "ParentListTodoListId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoItemID1",
                table: "TodoItems",
                column: "TodoItemID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoLists");
        }
    }
}
