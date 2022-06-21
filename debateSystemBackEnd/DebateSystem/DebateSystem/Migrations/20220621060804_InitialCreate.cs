using Microsoft.EntityFrameworkCore.Migrations;

namespace DebateSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopicCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_TopicCategories_TopicCategoryId",
                        column: x => x.TopicCategoryId,
                        principalTable: "TopicCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTopic",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTopic", x => new { x.ApplicationUsersId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTopic_ApplicationUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WrittenArgument",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Argument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenArgument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WrittenArgument_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrittenArgument_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Email",
                table: "ApplicationUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserName",
                table: "ApplicationUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTopic_TopicsId",
                table: "ApplicationUserTopic",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicCategories_CategoryName",
                table: "TopicCategories",
                column: "CategoryName",
                unique: true,
                filter: "[CategoryName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TopicCategoryId",
                table: "Topics",
                column: "TopicCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TopicName",
                table: "Topics",
                column: "TopicName",
                unique: true,
                filter: "[TopicName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenArgument_ApplicationUserId",
                table: "WrittenArgument",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenArgument_TopicId",
                table: "WrittenArgument",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTopic");

            migrationBuilder.DropTable(
                name: "WrittenArgument");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "TopicCategories");
        }
    }
}
