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
                    BirdID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.BirdID);
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
                    CatID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatID);
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
                    DogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogID);
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
                    { new Guid("045d4182-cd28-401d-be8b-007abb2d9105"), "Tiger", "Cat" },
                    { new Guid("09898173-fd9d-48ab-84ca-a8050a543a95"), "Maverick", "Bird" },
                    { new Guid("139121c5-e18a-4e66-a613-820ab065c915"), "Rose", "Cat" },
                    { new Guid("18951cee-1f2c-4a7e-be9e-1c04f4184902"), "Polly", "Bird" },
                    { new Guid("27a1fd69-423f-42b3-9573-6914b33f717c"), "NewG", "Dog" },
                    { new Guid("2f0fb393-fc1e-481c-8e41-fc90b258711e"), "Molly", "Cat" },
                    { new Guid("48635346-a311-4a4c-9410-c4f55e304dd9"), "Apollo", "Bird" },
                    { new Guid("553f3872-dc38-4d24-b63f-7dc747cbd85c"), "Skye", "Bird" },
                    { new Guid("65eb3f00-a585-4d73-bbd7-589c2f61e3de"), "Stanley", "Dog" },
                    { new Guid("6951237d-24e9-46ad-a5fa-525d3f005e66"), "Charlie", "Cat" },
                    { new Guid("69b059b7-c4c8-4ba4-b6ec-4bd9b79a7535"), "Daffy", "Bird" },
                    { new Guid("6cf2f038-545a-4106-aaeb-ef87708e2285"), "Jack", "Cat" },
                    { new Guid("7d3e352a-3560-4df0-a03a-8131d7c53286"), "Ludde", "Dog" },
                    { new Guid("7e1909ca-a291-4524-8d79-cbdc3519a805"), "Signe", "Cat" },
                    { new Guid("999b246c-71c7-4008-b823-5dbcf7dc74c1"), "Peppe", "Dog" },
                    { new Guid("9e9b684d-b5a1-4388-81f7-d079bdffadaa"), "Blue", "Bird" },
                    { new Guid("a9554639-2d39-4054-97c1-5f444b3a3c8d"), "Simba", "Cat" },
                    { new Guid("a9a96751-a9bb-4124-ba32-152d57534ded"), "Oscar", "Cat" },
                    { new Guid("b0f9c05d-f617-4297-8a18-5f5670802f8a"), "Jay", "Bird" },
                    { new Guid("b5657528-7eb6-4068-b55a-f54ac1a61fb6"), "Fred", "Cat" },
                    { new Guid("c0497ba8-b715-406e-a8fe-bdc88b6d9096"), "Björn", "Dog" },
                    { new Guid("c2ce0766-fe81-42dc-a957-5c5eeeec6b33"), "Rufus", "Dog" },
                    { new Guid("cb6cc4fe-52a6-47d3-a8df-6c1946b4090c"), "Felix", "Dog" },
                    { new Guid("e00cff79-927b-451a-ba9c-406c42635be2"), "Ace", "Bird" },
                    { new Guid("ef4c76ca-ae86-4276-a764-c0d33da81c6c"), "Chip", "Bird" },
                    { new Guid("f3ce2d2b-aae3-4aa3-a280-dae229e21aa4"), "Alfred", "Dog" },
                    { new Guid("f56b6393-4fab-4f94-bee5-4783d28b70de"), "Paulie", "Bird" },
                    { new Guid("f6b83270-68e9-45ec-82b7-4e8b700eb70b"), "Mittens", "Cat" },
                    { new Guid("f9562e70-45d3-4e4b-b4e5-4974fb47ba36"), "OldG", "Dog" },
                    { new Guid("fba79c58-c875-4e4b-80b9-5e250bbebd52"), "Patrik", "Dog" }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "BirdID", "AnimalID", "CanFly", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("09898173-fd9d-48ab-84ca-a8050a543a95"), null, false, "", "Maverick" },
                    { new Guid("18951cee-1f2c-4a7e-be9e-1c04f4184902"), null, false, "", "Polly" },
                    { new Guid("48635346-a311-4a4c-9410-c4f55e304dd9"), null, false, "", "Apollo" },
                    { new Guid("553f3872-dc38-4d24-b63f-7dc747cbd85c"), null, false, "", "Skye" },
                    { new Guid("69b059b7-c4c8-4ba4-b6ec-4bd9b79a7535"), null, false, "", "Daffy" },
                    { new Guid("9e9b684d-b5a1-4388-81f7-d079bdffadaa"), null, false, "", "Blue" },
                    { new Guid("b0f9c05d-f617-4297-8a18-5f5670802f8a"), null, false, "", "Jay" },
                    { new Guid("e00cff79-927b-451a-ba9c-406c42635be2"), null, false, "", "Ace" },
                    { new Guid("ef4c76ca-ae86-4276-a764-c0d33da81c6c"), null, false, "", "Chip" },
                    { new Guid("f56b6393-4fab-4f94-bee5-4783d28b70de"), null, false, "", "Paulie" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatID", "AnimalID", "Breed", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("045d4182-cd28-401d-be8b-007abb2d9105"), null, "", false, "Tiger", 0 },
                    { new Guid("139121c5-e18a-4e66-a613-820ab065c915"), null, "", false, "Rose", 0 },
                    { new Guid("2f0fb393-fc1e-481c-8e41-fc90b258711e"), null, "", false, "Molly", 0 },
                    { new Guid("6951237d-24e9-46ad-a5fa-525d3f005e66"), null, "", false, "Charlie", 0 },
                    { new Guid("6cf2f038-545a-4106-aaeb-ef87708e2285"), null, "", false, "Jack", 0 },
                    { new Guid("7e1909ca-a291-4524-8d79-cbdc3519a805"), null, "", false, "Signe", 0 },
                    { new Guid("a9554639-2d39-4054-97c1-5f444b3a3c8d"), null, "", false, "Simba", 0 },
                    { new Guid("a9a96751-a9bb-4124-ba32-152d57534ded"), null, "", false, "Oscar", 0 },
                    { new Guid("b5657528-7eb6-4068-b55a-f54ac1a61fb6"), null, "", false, "Fred", 0 },
                    { new Guid("f6b83270-68e9-45ec-82b7-4e8b700eb70b"), null, "", false, "Mittens", 0 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogID", "AnimalID", "Breed", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("27a1fd69-423f-42b3-9573-6914b33f717c"), null, "", "NewG", 0 },
                    { new Guid("65eb3f00-a585-4d73-bbd7-589c2f61e3de"), null, "", "Stanley", 0 },
                    { new Guid("7d3e352a-3560-4df0-a03a-8131d7c53286"), null, "", "Ludde", 0 },
                    { new Guid("999b246c-71c7-4008-b823-5dbcf7dc74c1"), null, "", "Peppe", 0 },
                    { new Guid("c0497ba8-b715-406e-a8fe-bdc88b6d9096"), null, "", "Björn", 0 },
                    { new Guid("c2ce0766-fe81-42dc-a957-5c5eeeec6b33"), null, "", "Rufus", 0 },
                    { new Guid("cb6cc4fe-52a6-47d3-a8df-6c1946b4090c"), null, "", "Felix", 0 },
                    { new Guid("f3ce2d2b-aae3-4aa3-a280-dae229e21aa4"), null, "", "Alfred", 0 },
                    { new Guid("f9562e70-45d3-4e4b-b4e5-4974fb47ba36"), null, "", "OldG", 0 },
                    { new Guid("fba79c58-c875-4e4b-80b9-5e250bbebd52"), null, "", "Patrik", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("9cf8a602-0159-440a-94a0-3849a3f90424"), true, "admin", "admin", null, "admin" }
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
