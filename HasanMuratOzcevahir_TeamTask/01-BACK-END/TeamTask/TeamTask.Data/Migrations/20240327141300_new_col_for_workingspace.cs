using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class new_col_for_workingspace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88a46cb9-0683-40cf-9e7c-cabac843470d", "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8dc52fa-b159-4ff9-a68a-eac4cc48cae7", "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88a46cb9-0683-40cf-9e7c-cabac843470d", "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 1, "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 3, "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 5, "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 2, "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" });

            migrationBuilder.DeleteData(
                table: "TaskUsers",
                keyColumns: new[] { "TaskId", "UserId" },
                keyValues: new object[] { 4, "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88a46cb9-0683-40cf-9e7c-cabac843470d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8dc52fa-b159-4ff9-a68a-eac4cc48cae7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4bc5058e-474a-44ea-b133-5ca250dae639");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WorkingSpaces",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate", "Priority" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4789), new DateTime(2024, 3, 29, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4790), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4790), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate", "Priority" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4791), new DateTime(2024, 3, 30, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4792), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4791), 1 });

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
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate", "Priority" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4794), new DateTime(2024, 3, 29, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4795), new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4794), 1 });

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
                columns: new[] { "CreatedDate", "Description", "ModifiedDate", "Title", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4470), "Benim çalışma alanım 1 harika bir çalışma alanı!", new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4482), "Benim çalışma alanım 1", "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "ModifiedDate", "Title", "UserId" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4488), "Benim çalışma alanım 2 harika bir çalışma alanı!", new DateTime(2024, 3, 27, 17, 13, 0, 539, DateTimeKind.Local).AddTicks(4489), "Benim çalışma alanım 2", "cee95bee-2eaf-4ba1-8910-379e47362f9d" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WorkingSpaces");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88a46cb9-0683-40cf-9e7c-cabac843470d", null, "User", "USER" },
                    { "d8dc52fa-b159-4ff9-a68a-eac4cc48cae7", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4bc5058e-474a-44ea-b133-5ca250dae639", 0, "b46caee0-b537-4bd8-9982-fee2f81d51dc", "muratoz@gmail.com", true, "Murat", "Öz", false, null, "MURATOZ@GMAIL.COM", "MURATOZ", "AQAAAAIAAYagAAAAEAkMAe4tRknKqDSV8yDKXcaDoa45bs7PywpRgMbxnnhZfJIxh41K9wnd77UG5I/rOQ==", "5555555555", false, "e7cd4dbd-3211-4af3-bf05-6e723949d5ae", false, "muratoz" },
                    { "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0", 0, "222110ba-ce5e-447e-a421-e3996a32162d", "engin@gmail.com", true, "Engin", "Niyazi", false, null, "ENGIN@GMAIL.COM", "ENGIN", "AQAAAAIAAYagAAAAEEFrjzdhoJ7mQ5N1fU0Ok3xy+Ldpq/cf9RYyNPtC7QQhEl9s0+cB6SZpKhMnBvASdg==", "5555555554", false, "3fbaeb68-aabe-48f4-8ae7-09ccb7476cdb", false, "engin" }
                });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(491), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(492), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(492) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(493), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(493) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(503), new DateTime(2024, 3, 22, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(504), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate", "Priority" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(509), new DateTime(2024, 3, 23, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(510), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(510), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate", "Priority" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(511), new DateTime(2024, 3, 24, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(512), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(511), 0 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(512), new DateTime(2024, 3, 22, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(513), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EndDate", "ModifiedDate", "Priority" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(514), new DateTime(2024, 3, 23, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(514), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(514), 0 });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(454), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(454), "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(459), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(459), "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaceComments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate", "UserId" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(462), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(463), "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate", "Title", "UserId" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(341), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(350), "My space", "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.UpdateData(
                table: "WorkingSpaces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate", "Title", "UserId" },
                values: new object[] { new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(355), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(355), "My space 2", "4bc5058e-474a-44ea-b133-5ca250dae639" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "88a46cb9-0683-40cf-9e7c-cabac843470d", "4bc5058e-474a-44ea-b133-5ca250dae639" },
                    { "d8dc52fa-b159-4ff9-a68a-eac4cc48cae7", "4bc5058e-474a-44ea-b133-5ca250dae639" },
                    { "88a46cb9-0683-40cf-9e7c-cabac843470d", "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" }
                });

            migrationBuilder.InsertData(
                table: "TaskUsers",
                columns: new[] { "TaskId", "UserId" },
                values: new object[,]
                {
                    { 1, "4bc5058e-474a-44ea-b133-5ca250dae639" },
                    { 3, "4bc5058e-474a-44ea-b133-5ca250dae639" },
                    { 5, "4bc5058e-474a-44ea-b133-5ca250dae639" },
                    { 2, "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" },
                    { 4, "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0" }
                });
        }
    }
}
