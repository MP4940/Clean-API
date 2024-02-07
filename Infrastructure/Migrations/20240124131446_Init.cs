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
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CanFly = table.Column<bool>(type: "bit", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikesToPlay = table.Column<bool>(type: "bit", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Dog_Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dog_Weight = table.Column<int>(type: "int", nullable: true)
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
                columns: new[] { "AnimalID", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("197ef754-ba01-4131-a489-3e10f017a97e"), "Bengal", "Cat", true, "Simba", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("22977236-9193-44a4-977e-6b3d1a2b6851"), "Bulldog", "Dog", "NewG", 4 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("37cf4fe4-5971-418f-86de-e9041bb3fd38"), false, "Yellow", "Bird", "Skye" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("3f2b76db-9e56-4d20-a891-afc836cd4798"), "Perser", "Cat", true, "Charlie", 3 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("5b8865c8-73db-48f8-bd6b-06ff2bc129d0"), "Labrador", "Dog", "OldG", 10 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("6361d7d6-1fe3-4e3a-96a1-15916264d498"), true, "Orange", "Bird", "Polly" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("646e9bd3-eda6-4f27-8ab8-1bd1593c0b8a"), "Labrador", "Dog", "Stanley", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("66582388-955a-474b-a1d8-8c88b234f9c3"), true, "Green", "Bird", "Daffy" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("73f2198c-c8bd-434d-b2c3-cc0b95dbc701"), "Perser", "Cat", false, "Tiger", 5 },
                    { new Guid("7b0c9162-bd4a-4197-9c8d-73a6105e330c"), "Burma", "Cat", true, "Oscar", 4 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("80e652c7-5520-4cc6-a34c-0bb48e3d3f0e"), true, "Yellow", "Bird", "Maverick" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("832a11d5-cf72-43c6-b081-ebe87119d4e1"), "Pudel", "Dog", "Alfred", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[,]
                {
                    { new Guid("98f350c8-6c1c-48d9-8092-eea48f2bded0"), false, "Red", "Bird", "Ace" },
                    { new Guid("9a6cf3fe-cb59-4ecb-bf77-cff89de244e7"), false, "Green", "Bird", "Apollo" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("9bba7692-c200-4fb5-a091-04252cb26a29"), "Rottweiler", "Dog", "Rufus", 8 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("a42f3ae3-5c38-4610-8fb8-1d89c5c4fdaf"), "Brittiskt korthår", "Cat", true, "Fred", 4 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("b19896b8-9740-4514-93a9-fafffed45911"), "Boxer", "Dog", "Ludde", 9 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("b47d3b4a-720c-4f2b-99dd-5f19c6c1b756"), false, "Red", "Bird", "Chip" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("b910c506-484b-4b8b-ab9d-c9c5b032a2f7"), "Siames", "Cat", true, "Jack", 3 },
                    { new Guid("bfa164e2-b1b0-4707-886f-fb8f7c815bfa"), "Ragdoll", "Cat", false, "Molly", 6 },
                    { new Guid("c0f78184-8293-4186-afc7-c5c92d8b08df"), "Ragdoll", "Cat", false, "Signe", 4 },
                    { new Guid("c9c3663d-b2b6-43ba-a423-064c63bc45a5"), "Burma", "Cat", true, "Mittens", 5 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("ce762ec5-93d6-48b1-8e17-fceef9a3cf89"), true, "Blue", "Bird", "Paulie" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[,]
                {
                    { new Guid("d45f169d-e7a4-4894-9feb-aa27d0600fd8"), "Golden retriever", "Dog", "Patrik", 13 },
                    { new Guid("d87deba0-4d76-4563-90c4-6c0ca3501cab"), "Boxer", "Dog", "Peppe", 8 },
                    { new Guid("e1aa5de6-cd87-40ed-885c-5719da9a4582"), "Schäfer", "Dog", "Björn", 12 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("e65d1f79-4cce-4d7e-afc9-c3e1e3fdfdc9"), true, "Purple", "Bird", "Blue" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Dog_Breed", "Discriminator", "Name", "Dog_Weight" },
                values: new object[] { new Guid("eae0fe3e-ea23-4a76-893a-cb246ccaf508"), "Labrador", "Dog", "Felix", 12 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Breed", "Discriminator", "LikesToPlay", "Name", "Weight" },
                values: new object[] { new Guid("f4f319e2-67b2-4053-a99d-6b74a8118e25"), "Bengal", "Cat", false, "Rose", 6 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "CanFly", "Color", "Discriminator", "Name" },
                values: new object[] { new Guid("f6583782-ee82-4700-b494-0b7388b2f53e"), true, "Purple", "Bird", "Jay" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-5678-1234-567812345674"), true, "password", "admin", null, "testUser2" },
                    { new Guid("c96690ba-bd60-496a-a212-0e6f2b358a61"), true, "admin", "admin", null, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_AnimalID",
                table: "AnimalUsers",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalUsers_UserID",
                table: "AnimalUsers",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalUsers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
