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
                name: "Bird",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bird", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.ID);
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

            migrationBuilder.InsertData(
                table: "Bird",
                columns: new[] { "ID", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("1f65aebe-3c91-42e2-9483-7f5d852a42e8"), false, "Paulie" },
                    { new Guid("254fb985-f914-460f-8b1a-a6297484484b"), false, "Daffy" },
                    { new Guid("4a1c2c51-f1a5-447d-84d1-58f1b5a1f744"), false, "Polly" },
                    { new Guid("5757d04a-0933-4353-8439-8bdd8415e8af"), false, "Skye" },
                    { new Guid("82c2ad03-ed9e-4ae1-adf1-d955f57faf77"), false, "Ace" },
                    { new Guid("9cab531b-579f-4f48-9578-43d329788b0f"), false, "Jay" },
                    { new Guid("ccd750ee-bcbf-47f7-a9f1-b570ee02eb12"), false, "Maverick" },
                    { new Guid("d8380ded-8622-4c0d-aedb-5b502b0057ad"), false, "Blue" },
                    { new Guid("e08fb859-d0ec-4378-afbb-63b9330b92b3"), false, "Apollo" },
                    { new Guid("fa0f2ffd-cc7e-4d1e-800a-64e69040ab08"), false, "Chip" }
                });

            migrationBuilder.InsertData(
                table: "Cat",
                columns: new[] { "ID", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("246e9545-2a8c-4134-976e-e565683d2c96"), false, "Jack" },
                    { new Guid("4fe37411-51bf-4000-b4a0-e4771e316e5e"), false, "Rose" },
                    { new Guid("5a9bc831-1518-4b14-a426-24083e4ad7b8"), false, "Fred" },
                    { new Guid("66af8755-5f17-4605-8cfb-bb870b9a5c06"), false, "Signe" },
                    { new Guid("9526cbb5-fcd1-4fbb-b35d-a1b13ef361af"), false, "Molly" },
                    { new Guid("c0a1aac2-8c49-4ebd-98f8-67a177f5d730"), false, "Charlie" },
                    { new Guid("c1fd6019-3330-48f6-ba89-1f9c8cb06518"), false, "Simba" },
                    { new Guid("cf580a3a-1345-44fe-9369-e6f64bf32183"), false, "Tiger" },
                    { new Guid("dfff162b-be84-424f-b89b-e56310fba3ee"), false, "Oscar" },
                    { new Guid("e9df5792-6beb-47d8-8950-ab44d4d8dd8f"), false, "Mittens" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("0e2e253a-95c9-4c3d-a783-db9c9501d48f"), "NewG" },
                    { new Guid("1af64659-424f-4aad-953c-1a3a057fdc25"), "Peppe" },
                    { new Guid("2db9bfdc-69c2-4e54-a5bc-f85ce516803d"), "Björn" },
                    { new Guid("380301db-d6c0-4443-bc5f-d1a62ea87b47"), "Ludde" },
                    { new Guid("3da577be-0e55-4d8e-b8db-598ca8ecc30f"), "Patrik" },
                    { new Guid("4b11e739-4a5a-4029-bdbe-dee231987bd7"), "Stanley" },
                    { new Guid("4de871ab-4f27-4ae7-a3af-92a7626bd065"), "Alfred" },
                    { new Guid("5a0347f0-fce1-4938-a797-dbd07dd235ea"), "OldG" },
                    { new Guid("ee16c6d8-8a8a-4c3b-b4e1-1bed16c1da1f"), "Felix" },
                    { new Guid("f4cfce40-f1ae-4922-86a4-884a1222abef"), "Rufus" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("f54a9199-7214-495a-ae89-3634c7969ee2"), true, "admin", "admin", null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bird");

            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
