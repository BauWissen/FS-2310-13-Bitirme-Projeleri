using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayText = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSpaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => new { x.StatusId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_TaskStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskStatuses_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUsers", x => new { x.UserId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_TaskUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUsers_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSpaceComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    WorkingSpaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSpaceComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingSpaceComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSpaceComments_WorkingSpaces_WorkingSpaceId",
                        column: x => x.WorkingSpaceId,
                        principalTable: "WorkingSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSpaceTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkingSpaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSpaceTasks", x => new { x.TaskId, x.WorkingSpaceId });
                    table.ForeignKey(
                        name: "FK_WorkingSpaceTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingSpaceTasks_WorkingSpaces_WorkingSpaceId",
                        column: x => x.WorkingSpaceId,
                        principalTable: "WorkingSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Color", "CreatedDate", "DisplayText", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "gray", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(491), "Başlanmadı", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(491) },
                    { 2, "yellow", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(492), "Sürüyor", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(492) },
                    { 3, "green", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(493), "Bitti", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(493) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "EndDate", "ModifiedDate", "Priority", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(503), new DateTime(2024, 3, 22, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(504), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(503), 0, "Task 1" },
                    { 2, new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(509), new DateTime(2024, 3, 23, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(510), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(510), 0, "Task 2" },
                    { 3, new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(511), new DateTime(2024, 3, 24, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(512), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(511), 0, "Task 3" },
                    { 4, new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(512), new DateTime(2024, 3, 22, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(513), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(513), 0, "Task 4" },
                    { 5, new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(514), new DateTime(2024, 3, 23, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(514), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(514), 0, "Task 5" }
                });

            migrationBuilder.InsertData(
                table: "WorkingSpaces",
                columns: new[] { "Id", "Color", "CreatedDate", "ModifiedDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "#ff0000", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(341), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(350), "My space", "4bc5058e-474a-44ea-b133-5ca250dae639" },
                    { 2, "#00ff00", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(355), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(355), "My space 2", "4bc5058e-474a-44ea-b133-5ca250dae639" }
                });

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
                table: "TaskStatuses",
                columns: new[] { "StatusId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 4 },
                    { 3, 5 }
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

            migrationBuilder.InsertData(
                table: "WorkingSpaceComments",
                columns: new[] { "Id", "Comment", "CreatedDate", "ModifiedDate", "UserId", "WorkingSpaceId" },
                values: new object[,]
                {
                    { 1, "Harika bir çalışma alanı", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(454), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(454), "4bc5058e-474a-44ea-b133-5ca250dae639", 1 },
                    { 2, "Güzel bir çalışma olacak", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(459), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(459), "bfc24732-ffe5-4caa-a8d5-79c074b7c0c0", 2 },
                    { 3, "Tekrar yorum yaptım", new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(462), new DateTime(2024, 3, 21, 19, 22, 10, 847, DateTimeKind.Local).AddTicks(463), "4bc5058e-474a-44ea-b133-5ca250dae639", 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkingSpaceTasks",
                columns: new[] { "TaskId", "WorkingSpaceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatuses_TaskId",
                table: "TaskStatuses",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskUsers_TaskId",
                table: "TaskUsers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSpaceComments_UserId",
                table: "WorkingSpaceComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSpaceComments_WorkingSpaceId",
                table: "WorkingSpaceComments",
                column: "WorkingSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSpaceTasks_WorkingSpaceId",
                table: "WorkingSpaceTasks",
                column: "WorkingSpaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "TaskUsers");

            migrationBuilder.DropTable(
                name: "WorkingSpaceComments");

            migrationBuilder.DropTable(
                name: "WorkingSpaceTasks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "WorkingSpaces");
        }
    }
}
