using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Simple_Blazor_Todo.Server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    TodoItemID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titel = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    TodoItemID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.TodoItemID);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoItems_TodoItemID1",
                        column: x => x.TodoItemID1,
                        principalTable: "TodoItems",
                        principalColumn: "TodoItemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoItemID1",
                table: "TodoItems",
                column: "TodoItemID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
