using Microsoft.EntityFrameworkCore.Migrations;

namespace DebateSystem.Migrations
{
    public partial class InitilizeDb : Migration
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
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopicTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTags", x => x.Id);
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
                name: "WrittenArguments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Argument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenArguments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WrittenArguments_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WrittenArguments_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicTopicTag",
                columns: table => new
                {
                    TopicsId = table.Column<int>(type: "int", nullable: false),
                    topicTagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicTopicTag", x => new { x.TopicsId, x.topicTagsId });
                    table.ForeignKey(
                        name: "FK_TopicTopicTag_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicTopicTag_TopicTags_topicTagsId",
                        column: x => x.topicTagsId,
                        principalTable: "TopicTags",
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
                name: "IX_Topics_TopicName",
                table: "Topics",
                column: "TopicName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicTags_Name",
                table: "TopicTags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicTopicTag_topicTagsId",
                table: "TopicTopicTag",
                column: "topicTagsId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenArguments_ApplicationUserId",
                table: "WrittenArguments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WrittenArguments_TopicId",
                table: "WrittenArguments",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTopic");

            migrationBuilder.DropTable(
                name: "TopicTopicTag");

            migrationBuilder.DropTable(
                name: "WrittenArguments");

            migrationBuilder.DropTable(
                name: "TopicTags");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
