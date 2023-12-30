using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnimalUserTest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("1f65aebe-3c91-42e2-9483-7f5d852a42e8"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("254fb985-f914-460f-8b1a-a6297484484b"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("4a1c2c51-f1a5-447d-84d1-58f1b5a1f744"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("5757d04a-0933-4353-8439-8bdd8415e8af"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("82c2ad03-ed9e-4ae1-adf1-d955f57faf77"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("9cab531b-579f-4f48-9578-43d329788b0f"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("ccd750ee-bcbf-47f7-a9f1-b570ee02eb12"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("d8380ded-8622-4c0d-aedb-5b502b0057ad"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("e08fb859-d0ec-4378-afbb-63b9330b92b3"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("fa0f2ffd-cc7e-4d1e-800a-64e69040ab08"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("246e9545-2a8c-4134-976e-e565683d2c96"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("4fe37411-51bf-4000-b4a0-e4771e316e5e"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("5a9bc831-1518-4b14-a426-24083e4ad7b8"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("66af8755-5f17-4605-8cfb-bb870b9a5c06"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("9526cbb5-fcd1-4fbb-b35d-a1b13ef361af"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("c0a1aac2-8c49-4ebd-98f8-67a177f5d730"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("c1fd6019-3330-48f6-ba89-1f9c8cb06518"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("cf580a3a-1345-44fe-9369-e6f64bf32183"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("dfff162b-be84-424f-b89b-e56310fba3ee"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("e9df5792-6beb-47d8-8950-ab44d4d8dd8f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("0e2e253a-95c9-4c3d-a783-db9c9501d48f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("1af64659-424f-4aad-953c-1a3a057fdc25"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("2db9bfdc-69c2-4e54-a5bc-f85ce516803d"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("380301db-d6c0-4443-bc5f-d1a62ea87b47"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("3da577be-0e55-4d8e-b8db-598ca8ecc30f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("4b11e739-4a5a-4029-bdbe-dee231987bd7"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("4de871ab-4f27-4ae7-a3af-92a7626bd065"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("5a0347f0-fce1-4938-a797-dbd07dd235ea"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("ee16c6d8-8a8a-4c3b-b4e1-1bed16c1da1f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("f4cfce40-f1ae-4922-86a4-884a1222abef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("f54a9199-7214-495a-ae89-3634c7969ee2"));

            migrationBuilder.InsertData(
                table: "Bird",
                columns: new[] { "ID", "CanFly", "Name" },
                values: new object[,]
                {
                    { new Guid("3ebf67c4-2621-406c-bc10-00fda4e76bf7"), false, "Polly" },
                    { new Guid("4cfd5f16-4fc1-4b71-8bab-f6d22a791bad"), false, "Chip" },
                    { new Guid("4ec7d216-ed10-4920-b54b-79c8098f8efe"), false, "Blue" },
                    { new Guid("58d02309-9542-458b-8c16-f99070f02462"), false, "Paulie" },
                    { new Guid("94b416fb-7d9d-4c6b-8337-860d87792658"), false, "Maverick" },
                    { new Guid("97071c12-8452-48f4-8c13-227dcc6f8c04"), false, "Ace" },
                    { new Guid("9af5cf28-505a-43a4-86be-ea70c014a862"), false, "Skye" },
                    { new Guid("afe8df4a-b612-48a0-91b0-e82d52e6f175"), false, "Apollo" },
                    { new Guid("d73aca67-8d27-4a88-a577-768185b08844"), false, "Daffy" },
                    { new Guid("e148aebc-98c0-4448-8dc1-757a08b9659e"), false, "Jay" }
                });

            migrationBuilder.InsertData(
                table: "Cat",
                columns: new[] { "ID", "LikesToPlay", "Name" },
                values: new object[,]
                {
                    { new Guid("1e12ff71-ac41-4c64-8dcb-246a10bb7432"), false, "Charlie" },
                    { new Guid("3f628163-62b0-436a-922b-800f0f1d9b7c"), false, "Rose" },
                    { new Guid("7e6bd537-bcd8-4d29-a9e9-53eef493206e"), false, "Signe" },
                    { new Guid("8bf5e3c4-6945-48ff-87bd-3be1045f5c80"), false, "Fred" },
                    { new Guid("9671240d-0081-4dd9-9f85-de1091c60ff0"), false, "Tiger" },
                    { new Guid("9fad63db-971b-4a34-919d-2d29a16aaa69"), false, "Oscar" },
                    { new Guid("a446eb46-8c81-4ba3-9aba-a6df905e8bcd"), false, "Mittens" },
                    { new Guid("acfb6556-999a-4b66-b515-1d80e8523325"), false, "Molly" },
                    { new Guid("cc67d7cd-84be-46b4-8016-73eecdceea23"), false, "Simba" },
                    { new Guid("e4bdf6f1-e7b1-4e15-a504-a2d57c9cb844"), false, "Jack" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("1606366f-0da5-48b3-9c19-625e590e00af"), "Alfred" },
                    { new Guid("32f0f92c-0100-4719-890d-786aff01182f"), "Stanley" },
                    { new Guid("359e2e4b-a07e-4db2-9b4f-2284a6a1b894"), "OldG" },
                    { new Guid("7095cbf9-50c3-4d07-aae8-e936797f7dcf"), "Peppe" },
                    { new Guid("822875f8-ab87-4f30-b863-f3f1b2036319"), "Björn" },
                    { new Guid("c9bbbee9-818f-4989-a80b-af882e5740de"), "NewG" },
                    { new Guid("db21abd9-472f-4b14-bdd9-d144ce7f2eb3"), "Ludde" },
                    { new Guid("df6e8c3b-3be6-44f8-8d6b-b42e12b9acfd"), "Rufus" },
                    { new Guid("f0ac1eeb-5e4e-435d-9a39-a54f12397609"), "Felix" },
                    { new Guid("fdd112c5-569e-4374-b017-60d8afc68129"), "Patrik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Authorized", "Password", "Role", "Token", "Username" },
                values: new object[] { new Guid("6e6ac3fb-ef4a-4d31-9d43-ac90e9a7516a"), true, "admin", "admin", null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("3ebf67c4-2621-406c-bc10-00fda4e76bf7"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("4cfd5f16-4fc1-4b71-8bab-f6d22a791bad"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("4ec7d216-ed10-4920-b54b-79c8098f8efe"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("58d02309-9542-458b-8c16-f99070f02462"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("94b416fb-7d9d-4c6b-8337-860d87792658"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("97071c12-8452-48f4-8c13-227dcc6f8c04"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("9af5cf28-505a-43a4-86be-ea70c014a862"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("afe8df4a-b612-48a0-91b0-e82d52e6f175"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("d73aca67-8d27-4a88-a577-768185b08844"));

            migrationBuilder.DeleteData(
                table: "Bird",
                keyColumn: "ID",
                keyValue: new Guid("e148aebc-98c0-4448-8dc1-757a08b9659e"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("1e12ff71-ac41-4c64-8dcb-246a10bb7432"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("3f628163-62b0-436a-922b-800f0f1d9b7c"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("7e6bd537-bcd8-4d29-a9e9-53eef493206e"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("8bf5e3c4-6945-48ff-87bd-3be1045f5c80"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("9671240d-0081-4dd9-9f85-de1091c60ff0"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("9fad63db-971b-4a34-919d-2d29a16aaa69"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("a446eb46-8c81-4ba3-9aba-a6df905e8bcd"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("acfb6556-999a-4b66-b515-1d80e8523325"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("cc67d7cd-84be-46b4-8016-73eecdceea23"));

            migrationBuilder.DeleteData(
                table: "Cat",
                keyColumn: "ID",
                keyValue: new Guid("e4bdf6f1-e7b1-4e15-a504-a2d57c9cb844"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("1606366f-0da5-48b3-9c19-625e590e00af"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("32f0f92c-0100-4719-890d-786aff01182f"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("359e2e4b-a07e-4db2-9b4f-2284a6a1b894"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("7095cbf9-50c3-4d07-aae8-e936797f7dcf"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("822875f8-ab87-4f30-b863-f3f1b2036319"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("c9bbbee9-818f-4989-a80b-af882e5740de"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("db21abd9-472f-4b14-bdd9-d144ce7f2eb3"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("df6e8c3b-3be6-44f8-8d6b-b42e12b9acfd"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("f0ac1eeb-5e4e-435d-9a39-a54f12397609"));

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: new Guid("fdd112c5-569e-4374-b017-60d8afc68129"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("6e6ac3fb-ef4a-4d31-9d43-ac90e9a7516a"));

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
                values: new object[] { new Guid("f54a9199-7214-495a-ae89-3634c7969ee2"), true, "admin", "admin", null, "admin" });
        }
    }
}
