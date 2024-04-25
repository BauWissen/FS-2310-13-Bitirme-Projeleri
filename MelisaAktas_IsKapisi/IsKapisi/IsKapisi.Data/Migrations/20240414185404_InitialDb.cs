using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IsKapisi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
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
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
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
                name: "CategoryJob",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryJob", x => new { x.CategoryId, x.JobId });
                    table.ForeignKey(
                        name: "FK_CategoryJob_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryJob_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDelete", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3960), "Eğitim Kategorisi", true, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3977), "Öğretmen", "ogretmen" },
                    { 2, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3982), "Hukuk", true, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3983), "Avukat", "avukat" },
                    { 3, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3984), "Bilgi İşlem", true, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3984), "Yazılım Geliştirme Uzmanı", "yazilim-geliştirme-uzmani" },
                    { 4, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3985), "İnsan Kaynaklari Uzmani", true, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3986), "İnsan Kaynaklari Uzmanı", "insan-kaynaklari-uzmani" },
                    { 5, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3987), "Developer", true, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(3987), "Back-End Developer", "back-end-developer" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "IsActive", "IsDelete", "IsHome", "ModifiedDate", "Name", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4836), null, "1.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4838), "Kimya Öğretmeni", "Deneyimli Öğretmen", "kimya-ogretmen" },
                    { 2, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4845), null, "2.png", true, false, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4846), "İnsan Kaynakları Uzmanı", " En az 3 yıl tecrübeli", "insan-kaynaklari-uzmani" },
                    { 3, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4847), null, "3.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4848), "Kıdemli Avukat", "Deneyimi 5 - 10 yıl arası", "avukat" },
                    { 4, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4849), null, "4.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4850), "Yazılım Destek Elemanı", "Tecrübeli/Tecrübesiz", "yazilim-destek-uzmani" },
                    { 5, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4851), null, "5.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4851), "Backend Developer (İstanbul-Ankara-İzmir)", "  En az 3 yıl deneyimli,", "back-end-gelistirici" },
                    { 6, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4853), null, "6.png", true, false, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4853), "React Front-End Geliştirici", "2 - 6 yıl arası", "react-front-end" },
                    { 7, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4854), null, "7.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4855), "React Native Developer", "En az 3 yıl deneyimli", "react-native" },
                    { 8, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4856), null, "8.png", true, false, false, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4856), "Data Science Professionals - Discovery (İstanbul, Ankara, İzmir)", "Uzman", "data-science" },
                    { 9, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4858), null, "9.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4858), "İdari İşler Profesyonelleri ", "Minimum 7 yıl idari işler alanında deneyimli", "idari-isler" },
                    { 10, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4859), null, "10.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4860), "Front-end Developer ", "Minimum 7 yıl react üzerinde çalışmış", "idari-isler" },
                    { 11, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4861), null, "11.png", true, false, true, new DateTime(2024, 4, 14, 21, 54, 3, 903, DateTimeKind.Local).AddTicks(4861), "Müzik Öğretmeni", "En az 10 yıl tecrübeli", "muzik-ogretmen" }
                });

            migrationBuilder.InsertData(
                table: "CategoryJob",
                columns: new[] { "CategoryId", "JobId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 11 },
                    { 2, 3 },
                    { 3, 4 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 10 },
                    { 4, 2 },
                    { 4, 9 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 8 }
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
                name: "IX_CategoryJob_JobId",
                table: "CategoryJob",
                column: "JobId");
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
                name: "CategoryJob");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
