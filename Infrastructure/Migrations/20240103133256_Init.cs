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
                name: "Animal",
                columns: table => new
                {
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalID);
                });

            migrationBuilder.CreateTable(
                name: "AnimalUsers",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUsers", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.ID);
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
                name: "AnimalUser",
                columns: table => new
                {
                    AnimalsAnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalUser", x => new { x.AnimalsAnimalID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_AnimalUser_Animal_AnimalsAnimalID",
                        column: x => x.AnimalsAnimalID,
                        principalTable: "Animal",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalUser_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Birds",
                columns: new[] { "ID", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("22415db2-cbc1-4097-a20a-f372a54f9ae3"), false, "Apollo" },
                    { new Guid("3b6c49dd-0e7d-4f4a-9645-ba4254f19591"), false, "Ace" },
                    { new Guid("52b4eb8e-9aa9-44bb-bf44-882cede8b1c6"), false, "Polly" },
                    { new Guid("5eeefd5e-8a34-4239-969b-d4e69342effe"), false, "Maverick" },
                    { new Guid("68a249fa-43fe-4034-afbe-350b901d1196"), false, "Daffy" },
                    { new Guid("7fbb291e-b4d0-4c0a-83e2-0e4db60972a2"), false, "Skye" },
                    { new Guid("a64972a9-f3dd-4913-9eea-2224f30035cf"), false, "Paulie" },
                    { new Guid("af7915b3-1f34-48b9-aed0-edd93965e1c9"), false, "Chip" },
                    { new Guid("d266b965-8f63-430e-b816-4832a10ab9fc"), false, "Blue" },
                    { new Guid("d9babcfe-fb4c-4483-97a3-92e8bd7c136f"), false, "Jay" }
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "ID", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("496d09b5-c67f-4a88-8696-e6f4d749f8c6"), false, "Rose" },
                    { new Guid("528fae60-1c86-4825-b315-bdd6db294a4e"), false, "Mittens" },
                    { new Guid("9241866f-459b-4926-9883-793ff1bd8ff1"), false, "Signe" },
                    { new Guid("c23168a4-e238-4c2c-8179-710b4376bc31"), false, "Fred" },
                    { new Guid("c50a74f3-ca5f-461b-a6c0-9ba773902318"), false, "Simba" },
                    { new Guid("c72ee6d4-66ee-45e2-a9c3-4b477b54bbfa"), false, "Tiger" },
                    { new Guid("d4562dea-1d3c-4f49-900e-f5206d5e3ad6"), false, "Oscar" },
                    { new Guid("edd464ee-4c70-4420-a86e-0cf5cde842c6"), false, "Charlie" },
                    { new Guid("fc7ce72f-b39f-4f41-9445-b3909ee41a6d"), false, "Molly" },
                    { new Guid("fd187582-c76b-4d33-863f-95f303185a95"), false, "Jack" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("0f67d6f3-a582-4a59-8d9c-64cf29ba27f0"), "Rufus" },
                    { new Guid("49165a33-a67f-489e-8da0-1f058d2d6fae"), "Björn" },
                    { new Guid("60805ceb-fa1d-4aa3-b642-2bee3196db49"), "Ludde" },
                    { new Guid("86782122-154c-42b8-a480-42bafca678bd"), "Alfred" },
                    { new Guid("95a6f178-ccdb-411d-9ea6-9f102ffe2843"), "Stanley" },
                    { new Guid("a415a527-63e7-446f-8c84-d574e725acde"), "Felix" },
                    { new Guid("c57b02f2-8a42-4955-acc4-1b3b51d2ae6c"), "Peppe" },
                    { new Guid("d0a9d8e6-b2ca-4205-9e9e-abb60eef9381"), "OldG" },
                    { new Guid("dde412ec-1f63-4f95-8a8f-8c1c03054ea4"), "NewG" },
                    { new Guid("efe0d39a-0eb9-46e9-b564-d7e92f4742d8"), "Patrik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("08f08c1f-fd93-4a36-be54-3f3efc27e837"), true, "admin", "admin", null, "admin" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUser_UsersID",
                table: "AnimalUser",
                column: "UsersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalUser");

            migrationBuilder.DropTable(
                name: "AnimalUsers");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
