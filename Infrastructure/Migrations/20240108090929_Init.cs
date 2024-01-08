using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Authorized = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Birds_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalID");
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cats_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalID");
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dogs_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalID");
                });

            migrationBuilder.CreateTable(
                name: "AnimalUsers",
                columns: table => new
                {
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUsers", x => x.Key);
                    table.ForeignKey(
                        name: "FK_AnimalUsers_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("02504f95-6003-46ee-aac2-3d6d2548d17e"), "Fred", "Cat" },
                    { new Guid("031dc261-1db9-4d5f-a41e-fa110dd615ca"), "Charlie", "Cat" },
                    { new Guid("03503de9-8804-49dd-9d4b-ea4f999c7fc3"), "Molly", "Cat" },
                    { new Guid("0355ffbe-eee3-49de-a33c-3fa17762e454"), "Maverick", "Bird" },
                    { new Guid("07b05f70-b4d3-42f8-a08a-d159f001f69f"), "Felix", "Dog" },
                    { new Guid("0ad2c029-7091-45b8-a1ae-ef524ad5dc75"), "Alfred", "Dog" },
                    { new Guid("0b301788-d64e-4594-a30e-922b5a4fa6ce"), "NewG", "Dog" },
                    { new Guid("18443ea7-ad72-49e5-98a2-7283f33edca7"), "Stanley", "Dog" },
                    { new Guid("1b66dd99-df6e-48b5-b758-c34986bfbacf"), "Daffy", "Bird" },
                    { new Guid("1ec80990-e04c-43de-9305-1f7f24d651a0"), "Skye", "Bird" },
                    { new Guid("1edd022a-3bee-48f3-ba3c-76d96fcb9139"), "Jay", "Bird" },
                    { new Guid("236587dd-d212-4652-a488-4de8ed28cd01"), "Paulie", "Bird" },
                    { new Guid("252c161c-d683-4834-b8a4-c1c8518e5ae8"), "Peppe", "Dog" },
                    { new Guid("2bdc570f-2dfc-4030-a7a0-aa941c8f7d8a"), "Björn", "Dog" },
                    { new Guid("2e0e770a-664b-4e27-b5b8-2887efa9776e"), "Tiger", "Cat" },
                    { new Guid("36aacbc7-9116-45c5-955c-1c136ec1c907"), "Ace", "Bird" },
                    { new Guid("47161f1d-208b-4dd9-b940-9610b3db0388"), "Oscar", "Cat" },
                    { new Guid("51ab4d02-67ec-4dd7-9cc6-48776fe085ec"), "OldG", "Dog" },
                    { new Guid("68b98483-ce21-447c-8e35-86bb5ec36b9a"), "Blue", "Bird" },
                    { new Guid("6dffb82f-413b-4de0-a38f-4091c6ec85a8"), "Signe", "Cat" },
                    { new Guid("6f2a781a-00cf-4b96-984e-417de0ff32ac"), "Rufus", "Dog" },
                    { new Guid("7a252ddc-fc86-454b-823c-2f66514b96cc"), "Apollo", "Bird" },
                    { new Guid("93b9ce5b-702a-48ba-94b0-28e7be4238c0"), "Patrik", "Dog" },
                    { new Guid("9863866a-5fa8-4da0-a658-cd8d8b3e13d0"), "Jack", "Cat" },
                    { new Guid("a1df3dd3-eb8d-46c6-a975-02f2fce5ab67"), "Rose", "Cat" },
                    { new Guid("a35114a7-780e-4125-a867-5e7aed7c3862"), "Simba", "Cat" },
                    { new Guid("a87ffa33-8f03-44d4-9bf5-b30457ef9b8e"), "Polly", "Bird" },
                    { new Guid("d85d2592-1bac-4ec6-98ed-2808b178a76d"), "Ludde", "Dog" },
                    { new Guid("db39b87a-071a-4c19-9bb2-032182f83806"), "Chip", "Bird" },
                    { new Guid("e5441e24-19ff-41b0-bb3a-46185e28e797"), "Mittens", "Cat" }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "ID", "AnimalID", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("0355ffbe-eee3-49de-a33c-3fa17762e454"), null, false, "Maverick" },
                    { new Guid("1b66dd99-df6e-48b5-b758-c34986bfbacf"), null, false, "Daffy" },
                    { new Guid("1ec80990-e04c-43de-9305-1f7f24d651a0"), null, false, "Skye" },
                    { new Guid("1edd022a-3bee-48f3-ba3c-76d96fcb9139"), null, false, "Jay" },
                    { new Guid("236587dd-d212-4652-a488-4de8ed28cd01"), null, false, "Paulie" },
                    { new Guid("36aacbc7-9116-45c5-955c-1c136ec1c907"), null, false, "Ace" },
                    { new Guid("68b98483-ce21-447c-8e35-86bb5ec36b9a"), null, false, "Blue" },
                    { new Guid("7a252ddc-fc86-454b-823c-2f66514b96cc"), null, false, "Apollo" },
                    { new Guid("a87ffa33-8f03-44d4-9bf5-b30457ef9b8e"), null, false, "Polly" },
                    { new Guid("db39b87a-071a-4c19-9bb2-032182f83806"), null, false, "Chip" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "ID", "AnimalID", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("02504f95-6003-46ee-aac2-3d6d2548d17e"), null, false, "Fred" },
                    { new Guid("031dc261-1db9-4d5f-a41e-fa110dd615ca"), null, false, "Charlie" },
                    { new Guid("03503de9-8804-49dd-9d4b-ea4f999c7fc3"), null, false, "Molly" },
                    { new Guid("2e0e770a-664b-4e27-b5b8-2887efa9776e"), null, false, "Tiger" },
                    { new Guid("47161f1d-208b-4dd9-b940-9610b3db0388"), null, false, "Oscar" },
                    { new Guid("6dffb82f-413b-4de0-a38f-4091c6ec85a8"), null, false, "Signe" },
                    { new Guid("9863866a-5fa8-4da0-a658-cd8d8b3e13d0"), null, false, "Jack" },
                    { new Guid("a1df3dd3-eb8d-46c6-a975-02f2fce5ab67"), null, false, "Rose" },
                    { new Guid("a35114a7-780e-4125-a867-5e7aed7c3862"), null, false, "Simba" },
                    { new Guid("e5441e24-19ff-41b0-bb3a-46185e28e797"), null, false, "Mittens" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "ID", "AnimalID", "Name" },
                values: new object[,]
                {
                    { new Guid("07b05f70-b4d3-42f8-a08a-d159f001f69f"), null, "Felix" },
                    { new Guid("0ad2c029-7091-45b8-a1ae-ef524ad5dc75"), null, "Alfred" },
                    { new Guid("0b301788-d64e-4594-a30e-922b5a4fa6ce"), null, "NewG" },
                    { new Guid("18443ea7-ad72-49e5-98a2-7283f33edca7"), null, "Stanley" },
                    { new Guid("252c161c-d683-4834-b8a4-c1c8518e5ae8"), null, "Peppe" },
                    { new Guid("2bdc570f-2dfc-4030-a7a0-aa941c8f7d8a"), null, "Björn" },
                    { new Guid("51ab4d02-67ec-4dd7-9cc6-48776fe085ec"), null, "OldG" },
                    { new Guid("6f2a781a-00cf-4b96-984e-417de0ff32ac"), null, "Rufus" },
                    { new Guid("93b9ce5b-702a-48ba-94b0-28e7be4238c0"), null, "Patrik" },
                    { new Guid("d85d2592-1bac-4ec6-98ed-2808b178a76d"), null, "Ludde" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("86c0791c-886e-4535-a6a6-d2621613a907"), true, "admin", "admin", null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_AnimalID",
                table: "AnimalUsers",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_UserID",
                table: "AnimalUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Birds_AnimalID",
                table: "Birds",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_AnimalID",
                table: "Cats",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_AnimalID",
                table: "Dogs",
                column: "AnimalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalUsers");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
