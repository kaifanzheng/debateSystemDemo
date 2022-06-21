using Microsoft.EntityFrameworkCore.Migrations;

namespace DebateSystem.Migrations
{
    public partial class CreateRequiredAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_TopicName",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_TopicCategories_CategoryName",
                table: "TopicCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Argument",
                table: "WrittenArgument",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TopicName",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "TopicCategories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TopicCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TopicName",
                table: "Topics",
                column: "TopicName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicCategories_CategoryName",
                table: "TopicCategories",
                column: "CategoryName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_TopicName",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_TopicCategories_CategoryName",
                table: "TopicCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TopicCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Argument",
                table: "WrittenArgument",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TopicName",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "TopicCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TopicName",
                table: "Topics",
                column: "TopicName",
                unique: true,
                filter: "[TopicName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TopicCategories_CategoryName",
                table: "TopicCategories",
                column: "CategoryName",
                unique: true,
                filter: "[CategoryName] IS NOT NULL");
        }
    }
}
