using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class userNoteTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b66d5a45-dca6-4a42-8329-b18f1eab41d3", "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b66d5a45-dca6-4a42-8329-b18f1eab41d3", "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dba5ba2b-7661-47ef-b466-0947a595dd7e", "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 2, "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 4, "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 1, "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 3, "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 5, "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b66d5a45-dca6-4a42-8329-b18f1eab41d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dba5ba2b-7661-47ef-b466-0947a595dd7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cee95bee-2eaf-4ba1-8910-379e47362f9d");

            migrationBuilder.CreateTable(
                name: "UserNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    NoteTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58fd95fc-2c1f-420d-967e-cadc3b498475", null, "User", "USER" },
                    { "ee2b7220-4f94-4237-a019-f53e67619be5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4", 0, "526dfc69-e892-470f-9f40-1c3c4b19910b", "engin@gmail.com", true, "Engin", "Niyazi", false, null, "ENGIN@GMAIL.COM", "ENGIN", "AQAAAAIAAYagAAAAEIXrfZOquYwTwcGs5aVyp6AZ7+Gjrq/ZEzvwYrRtgiPgpbmbC9n5cpJaicza4n+gEQ==", "5555555554", false, "c8fe5fc5-1475-4e00-8cbc-f99dfd392a6f", false, "engin" },
                    { "449d244c-5a63-4ca4-b19f-0c9a0cdef696", 0, "620eed8d-798f-49f5-89ae-346904014e50", "muratoz@gmail.com", true, "Murat", "Öz", false, null, "MURATOZ@GMAIL.COM", "MURATOZ", "AQAAAAIAAYagAAAAEOXXQ53mg0egXu7WYwpta5n5daJRPqjxTjh5fwZsl7tnH1JMy7e9xZ9flFx0hHbobQ==", "5555555555", false, "b8d21030-2052-4cc1-af2f-7301bc960502", false, "muratoz" }
                });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1547), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1548), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1549) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1550), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1550) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1560), new DateTime(2024, 4, 2, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1561), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1565), new DateTime(2024, 4, 3, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1566), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1566) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1567), new DateTime(2024, 4, 4, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1568), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1567) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1568), new DateTime(2024, 4, 2, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1569), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1569) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1570), new DateTime(2024, 4, 3, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1570), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1570) });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1517), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1518), "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1521), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1522), "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1523), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1524), "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1400), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1401), "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1403), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1404), "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "58fd95fc-2c1f-420d-967e-cadc3b498475", "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" },
                    { "58fd95fc-2c1f-420d-967e-cadc3b498475", "449d244c-5a63-4ca4-b19f-0c9a0cdef696" },
                    { "ee2b7220-4f94-4237-a019-f53e67619be5", "449d244c-5a63-4ca4-b19f-0c9a0cdef696" }
                });

            migrationBuilder.InsertData(
                table: "TaskUsers",
                columns: new[] { "TaskId", "UserId" },
                values: new object[,]
                {
                    { 2, "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" },
                    { 4, "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" },
                    { 1, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" },
                    { 3, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" },
                    { 5, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" }
                });

            migrationBuilder.InsertData(
                table: "UserNote",
                columns: new[] { "Id", "Content", "CreatedDate", "ModifiedDate", "NoteTitle", "Priority", "UserId" },
                values: new object[,]
                {
                    { 1, "Bu benim test notumdur!", new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1337), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1351), "Bunu unutma", 2, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" },
                    { 2, "Bu benim test notumdur2!", new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1356), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1357), "Bunu unutma 2", 1, "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" },
                    { 3, "Bu benim test notumdur3!", new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1358), new DateTime(2024, 4, 1, 13, 4, 21, 257, DateTimeKind.Local).AddTicks(1358), "Bunu unutma 3", 0, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNote_UserId",
                table: "UserNote",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNote");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58fd95fc-2c1f-420d-967e-cadc3b498475", "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58fd95fc-2c1f-420d-967e-cadc3b498475", "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ee2b7220-4f94-4237-a019-f53e67619be5", "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 2, "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 4, "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 1, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 3, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 5, "449d244c-5a63-4ca4-b19f-0c9a0cdef696" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58fd95fc-2c1f-420d-967e-cadc3b498475");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee2b7220-4f94-4237-a019-f53e67619be5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28c3df3a-1ed1-4fdb-841b-836fc9eba5f4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "449d244c-5a63-4ca4-b19f-0c9a0cdef696");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b66d5a45-dca6-4a42-8329-b18f1eab41d3", null, "User", "USER" },
                    { "dba5ba2b-7661-47ef-b466-0947a595dd7e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8", 0, "4f55613f-622c-4054-8a57-8b856141a573", "engin@gmail.com", true, "Engin", "Niyazi", false, null, "ENGIN@GMAIL.COM", "ENGIN", "AQAAAAIAAYagAAAAEAXX1oEJndiqfnU0eiLI1jd3q8ZnFXIysMQky7y9+Ngf1aajXkTNXhusL67hRZ/kZg==", "5555555554", false, "d48171f4-b184-4e61-aa1d-fff692d47e2e", false, "engin" },
                    { "cee95bee-2eaf-4ba1-8910-379e47362f9d", 0, "25febed4-8bcc-46c7-9bf1-e7843635feb8", "muratoz@gmail.com", true, "Murat", "Öz", false, null, "MURATOZ@GMAIL.COM", "MURATOZ", "AQAAAAIAAYagAAAAEMKE9YvWpJahwDAo537kZnaXc3CRPPh54qZ6pT37wqJsKZ0JdpwtNldFc4lT0pNHRw==", "5555555555", false, "6b60960d-733a-45fb-b479-b8de1eba8e9e", false, "muratoz" }
                });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4771), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4773), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4773) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4774), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4774) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4784), new DateTime(2024, 3, 28, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4785), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4784) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4789), new DateTime(2024, 3, 29, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4790), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4791), new DateTime(2024, 3, 30, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4792), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 3, 28, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4793), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4793) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4794), new DateTime(2024, 3, 29, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4795), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4714), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4714), "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4744), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4744), "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4746), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4746), "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4470), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4482), "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4488), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4489), "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b66d5a45-dca6-4a42-8329-b18f1eab41d3", "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" },
                    { "b66d5a45-dca6-4a42-8329-b18f1eab41d3", "cee95bee-2eaf-4ba1-8910-379e47362f9d" },
                    { "dba5ba2b-7661-47ef-b466-0947a595dd7e", "cee95bee-2eaf-4ba1-8910-379e47362f9d" }
                });

            migrationBuilder.InsertData(
                table: "TaskUsers",
                columns: new[] { "TaskId", "UserId" },
                values: new object[,]
                {
                    { 2, "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" },
                    { 4, "1c5ff9fb-8377-4cf8-b5e0-1105e2cb94f8" },
                    { 1, "cee95bee-2eaf-4ba1-8910-379e47362f9d" },
                    { 3, "cee95bee-2eaf-4ba1-8910-379e47362f9d" },
                    { 5, "cee95bee-2eaf-4ba1-8910-379e47362f9d" }
                });
        }
    }
}
