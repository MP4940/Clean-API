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
                    { new Guid("01df08f7-f0e8-433b-aed0-c426ae257fcc"), "Jack", "Cat" },
                    { new Guid("0303504c-ec24-401a-860c-1ac0ae9f12ff"), "Chip", "Bird" },
                    { new Guid("1e34fb48-58b3-4685-a38b-1b381fa07e22"), "Rose", "Cat" },
                    { new Guid("2112ef42-3c65-400b-aa15-2891b4fbb6f0"), "Molly", "Cat" },
                    { new Guid("221d53e4-1e0f-44a7-93a0-dd14dc8104b3"), "Skye", "Bird" },
                    { new Guid("24dc68c6-6980-46f6-b23f-e3abccc0a0f1"), "Blue", "Bird" },
                    { new Guid("25925cfb-a43a-490d-852d-69f8a085d0fb"), "Patrik", "Dog" },
                    { new Guid("2dbbd568-78e0-42ff-a675-bf268adf598e"), "Jay", "Bird" },
                    { new Guid("33d22b2d-db29-482a-9c87-225ab75592ed"), "Oscar", "Cat" },
                    { new Guid("37a7f1e7-7c39-4a9f-a72b-d5022d61c021"), "Signe", "Cat" },
                    { new Guid("3d5fa03c-a75c-4eff-81c4-d0e1c7f82ff3"), "Ludde", "Dog" },
                    { new Guid("3deb994b-b559-40cf-8003-40d644fcfc8a"), "Paulie", "Bird" },
                    { new Guid("57bb1c98-5da1-4552-aa00-921bdb53e542"), "Stanley", "Dog" },
                    { new Guid("5c65250c-21ae-4e92-b6b7-2a42f311edc3"), "Felix", "Dog" },
                    { new Guid("5cb27aea-7288-46a2-80dc-1715a6d35c29"), "Tiger", "Cat" },
                    { new Guid("6ccc4bd2-ff46-45ed-8a71-03a4318714e8"), "Polly", "Bird" },
                    { new Guid("753b16a5-479e-4528-a75d-5e98033cd0c1"), "Rufus", "Dog" },
                    { new Guid("7a50bfdc-e200-41e8-9769-e70f77147cda"), "Maverick", "Bird" },
                    { new Guid("7da9bbfa-0ff4-4758-941b-55dedda0aca7"), "Mittens", "Cat" },
                    { new Guid("a4ba4856-b64b-4697-adde-516c9f856fa5"), "Simba", "Cat" },
                    { new Guid("aa9cd7c2-a702-4658-a09a-5f4f622873e2"), "NewG", "Dog" },
                    { new Guid("b18205d4-17ca-4233-93dd-8923154eeba4"), "Ace", "Bird" },
                    { new Guid("d0278d8a-e841-4639-841a-4d9b5a5935de"), "Alfred", "Dog" },
                    { new Guid("d0ddb4a7-9369-4b3f-9c2a-5b3e282235ef"), "Charlie", "Cat" },
                    { new Guid("dc1f1b5a-50ae-4b21-ba80-7919403d2634"), "Fred", "Cat" },
                    { new Guid("dd622008-e534-46d2-8df8-6fa330f16ebb"), "Björn", "Dog" },
                    { new Guid("e7775aaf-f27c-469e-b17d-0c88590e1fc4"), "OldG", "Dog" },
                    { new Guid("f1233b7a-ba0e-464f-8633-6ddcd45962b9"), "Apollo", "Bird" },
                    { new Guid("f56a5dc5-35df-4f8a-b255-294fbd812891"), "Daffy", "Bird" },
                    { new Guid("f7b4f4ae-19d2-4fd6-bfcc-536921b3a867"), "Peppe", "Dog" }
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "BirdID", "AnimalID", "CanFly", "Color", "Name" },
                values: new object[,]
                {
                    { new Guid("0303504c-ec24-401a-860c-1ac0ae9f12ff"), null, false, "Red", "Chip" },
                    { new Guid("221d53e4-1e0f-44a7-93a0-dd14dc8104b3"), null, false, "Yellow", "Skye" },
                    { new Guid("24dc68c6-6980-46f6-b23f-e3abccc0a0f1"), null, true, "Purple", "Blue" },
                    { new Guid("2dbbd568-78e0-42ff-a675-bf268adf598e"), null, true, "Purple", "Jay" },
                    { new Guid("3deb994b-b559-40cf-8003-40d644fcfc8a"), null, true, "Blue", "Paulie" },
                    { new Guid("6ccc4bd2-ff46-45ed-8a71-03a4318714e8"), null, true, "Orange", "Polly" },
                    { new Guid("7a50bfdc-e200-41e8-9769-e70f77147cda"), null, true, "Yellow", "Maverick" },
                    { new Guid("b18205d4-17ca-4233-93dd-8923154eeba4"), null, false, "Red", "Ace" },
                    { new Guid("f1233b7a-ba0e-464f-8633-6ddcd45962b9"), null, false, "Green", "Apollo" },
                    { new Guid("f56a5dc5-35df-4f8a-b255-294fbd812891"), null, true, "Green", "Daffy" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatID", "AnimalID", "Breed", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("01df08f7-f0e8-433b-aed0-c426ae257fcc"), null, "Siames", true, "Jack", 3 },
                    { new Guid("1e34fb48-58b3-4685-a38b-1b381fa07e22"), null, "Bengal", false, "Rose", 6 },
                    { new Guid("2112ef42-3c65-400b-aa15-2891b4fbb6f0"), null, "Ragdoll", false, "Molly", 6 },
                    { new Guid("33d22b2d-db29-482a-9c87-225ab75592ed"), null, "Burma", true, "Oscar", 4 },
                    { new Guid("37a7f1e7-7c39-4a9f-a72b-d5022d61c021"), null, "Ragdoll", false, "Signe", 4 },
                    { new Guid("5cb27aea-7288-46a2-80dc-1715a6d35c29"), null, "Perser", false, "Tiger", 5 },
                    { new Guid("7da9bbfa-0ff4-4758-941b-55dedda0aca7"), null, "Burma", true, "Mittens", 5 },
                    { new Guid("a4ba4856-b64b-4697-adde-516c9f856fa5"), null, "Bengal", true, "Simba", 6 },
                    { new Guid("d0ddb4a7-9369-4b3f-9c2a-5b3e282235ef"), null, "Perser", true, "Charlie", 3 },
                    { new Guid("dc1f1b5a-50ae-4b21-ba80-7919403d2634"), null, "Brittiskt korthår", true, "Fred", 4 }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "DogID", "AnimalID", "Breed", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("25925cfb-a43a-490d-852d-69f8a085d0fb"), null, "Golden retriever", "Patrik", 13 },
                    { new Guid("3d5fa03c-a75c-4eff-81c4-d0e1c7f82ff3"), null, "Boxer", "Ludde", 9 },
                    { new Guid("57bb1c98-5da1-4552-aa00-921bdb53e542"), null, "Labrador", "Stanley", 6 },
                    { new Guid("5c65250c-21ae-4e92-b6b7-2a42f311edc3"), null, "Labrador", "Felix", 12 },
                    { new Guid("753b16a5-479e-4528-a75d-5e98033cd0c1"), null, "Rottweiler", "Rufus", 8 },
                    { new Guid("aa9cd7c2-a702-4658-a09a-5f4f622873e2"), null, "Bulldog", "NewG", 4 },
                    { new Guid("d0278d8a-e841-4639-841a-4d9b5a5935de"), null, "Pudel", "Alfred", 6 },
                    { new Guid("dd622008-e534-46d2-8df8-6fa330f16ebb"), null, "Schäfer", "Björn", 12 },
                    { new Guid("e7775aaf-f27c-469e-b17d-0c88590e1fc4"), null, "Labrador", "OldG", 10 },
                    { new Guid("f7b4f4ae-19d2-4fd6-bfcc-536921b3a867"), null, "Boxer", "Peppe", 8 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("10ba5986-c597-44a9-b87f-093d6c102ca2"), true, "admin", "admin", null, "admin" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" }
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
