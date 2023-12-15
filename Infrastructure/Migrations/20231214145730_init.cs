using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Dogs",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("0052b0bd-3130-410f-a65b-a19a8936115a"), "OldG" },
                    { new Guid("12345678-1234-5678-1234-567812345671"), "TestDogForUnitTests1" },
                    { new Guid("12345678-1234-5678-1234-567812345672"), "TestDogForUnitTests2" },
                    { new Guid("12345678-1234-5678-1234-567812345673"), "TestDogForUnitTests3" },
                    { new Guid("12345678-1234-5678-1234-567812345674"), "TestDogForUnitTests4" },
                    { new Guid("3a065c75-6ec7-4b41-b722-5ce51b2d4bdf"), "Björn" },
                    { new Guid("622ead5c-afd4-428c-a74d-2b9f8773e4eb"), "Alfred" },
                    { new Guid("b2e06bbc-fec8-4a0c-921f-a401e8c578b0"), "NewG" },
                    { new Guid("bb2d8b27-4655-4181-9213-b0f9356d894e"), "Patrik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[] { new Guid("64d0a33d-4796-4e0b-bac7-4a5c8839dd2b"), true, "admin", null, null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
