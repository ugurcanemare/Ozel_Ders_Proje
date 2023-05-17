using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OzelDers.Data.Migrations
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
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Town = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    School = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    LessonClass = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    LessonPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LessonClassCategories",
                columns: table => new
                {
                    LessonClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonClassCategories", x => new { x.LessonClassId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_LessonClassCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonClassCategories_LessonClasses_LessonClassId",
                        column: x => x.LessonClassId,
                        principalTable: "LessonClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonCategories",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonCategories", x => new { x.LessonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_LessonCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonCategories_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<string>(type: "TEXT", nullable: true),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCategories", x => new { x.CategoryId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCategories_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => new { x.ClassId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentClasses_LessonClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "LessonClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCategories", x => new { x.CategoryId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCategories_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherLessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherLessons", x => new { x.LessonId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherLessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35993d49-d9c0-4b8e-8843-af44a1fc9eff", null, "Öğretmenler", "Teacher", "TEACHER" },
                    { "8a889228-b211-42fd-a343-775af104dee0", null, "Yöneticiler", "Admin", "ADMIN" },
                    { "c5d17273-aedc-4aa4-b512-1440b4d91ec7", null, "Öğrenciler", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "CreatedDate", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "School", "SecurityStamp", "Town", "TwoFactorEnabled", "Url", "UserName" },
                values: new object[] { "41bb57c4-67bf-4293-9925-94478bdf244d", 0, "Beşiktaş", "53ba10a7-15bd-4742-8c46-242d5e8ba834", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ugurcan@gmail.com", true, "Uğurcan", "Erkek", "Emare", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UGURCAN@GMAIL.COM", "UGURCAN", "AQAAAAIAAYagAAAAELt3SDLDo1Mf8s3yiPXKhr/FcmjxgiZOOHkpPQM8SFoRavL4HrkicW58cQkf2ZjbMA==", null, false, null, "0dd5618a-ede9-4b2d-9e61-f0226c4922cc", "İstanbul", false, null, "ugurcan" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8798), true, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8810), "İlk Okul", "ilk-okul" },
                    { 2, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8813), true, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8814), "Orta Okul", "orta-okul" },
                    { 3, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8815), true, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8816), "Lise", "lise" },
                    { 4, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8817), true, new DateTime(2023, 5, 15, 0, 56, 42, 758, DateTimeKind.Local).AddTicks(8818), "Üniversite", "universite" }
                });

            migrationBuilder.InsertData(
                table: "LessonClasses",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9325), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9332), "1. Sınıf", "1-sınıf" },
                    { 2, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9334), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9335), "2. Sınıf", "2-sınıf" },
                    { 3, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9336), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9337), "3. Sınıf", "3-sınıf" },
                    { 4, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9338), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9339), "4. Sınıf", "4-sınıf" },
                    { 5, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9340), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9340), "5. Sınıf", "5-sınıf" },
                    { 6, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9342), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9342), "6. Sınıf", "6-sınıf" },
                    { 7, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9344), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9344), "7. Sınıf", "7-sınıf" },
                    { 8, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9345), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9346), "8. Sınıf", "8-sınıf" },
                    { 9, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9347), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9348), "9. Sınıf", "9-sınıf" },
                    { 10, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9349), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9350), "10. Sınıf", "10-sınıf" },
                    { 11, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9351), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9352), "11. Sınıf", "11-sınıf" },
                    { 12, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9353), false, new DateTime(2023, 5, 15, 0, 56, 42, 759, DateTimeKind.Local).AddTicks(9353), "12. Sınıf", "12-sınıf" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedDate", "IsApproved", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1532), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1536), "Matematik", "matematik" },
                    { 2, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1538), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1538), "Fizik", "fizik" },
                    { 3, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1540), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1541), "Kimya", "kimya" },
                    { 4, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1542), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1542), "Biyoloji", "biyoloji" },
                    { 5, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1544), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1544), "Hayat Bilgisi", "hayat-bilgisi" },
                    { 6, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1546), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1546), "Sosyal Bilgiler", "sosyal-bilgiler" },
                    { 7, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1547), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1548), "İnkılap Tarihi", "inkilap-tarihi" },
                    { 8, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1549), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1550), "Felsefe", "felsefe" },
                    { 9, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1551), false, new DateTime(2023, 5, 15, 0, 56, 42, 760, DateTimeKind.Local).AddTicks(1552), "Din Kültürü ve Ahlak Bilgisi", "din-bilgisi-ve-ahlak-bilgisi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8a889228-b211-42fd-a343-775af104dee0", "41bb57c4-67bf-4293-9925-94478bdf244d" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "41bb57c4-67bf-4293-9925-94478bdf244d" });

            migrationBuilder.InsertData(
                table: "LessonCategories",
                columns: new[] { "CategoryId", "LessonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 6 },
                    { 2, 7 },
                    { 3, 7 },
                    { 3, 8 },
                    { 1, 9 },
                    { 2, 9 },
                    { 3, 9 }
                });

            migrationBuilder.InsertData(
                table: "LessonClassCategories",
                columns: new[] { "CategoryId", "LessonClassId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 }
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
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonCategories_CategoryId",
                table: "LessonCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonClassCategories_CategoryId",
                table: "LessonClassCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCategories_StudentId",
                table: "StudentCategories",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCategories_TeacherId",
                table: "TeacherCategories",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLessons_TeacherId",
                table: "TeacherLessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId",
                unique: true);
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LessonCategories");

            migrationBuilder.DropTable(
                name: "LessonClassCategories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "StudentCategories");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "TeacherCategories");

            migrationBuilder.DropTable(
                name: "TeacherLessons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "LessonClasses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
