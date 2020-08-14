using Microsoft.EntityFrameworkCore.Migrations;

namespace Simple_Blazor_Todo.Server.Migrations
{
    public partial class changedReferenceToTodoList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentListTodoListId",
                table: "TodoItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentListTodoListId",
                table: "TodoItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
