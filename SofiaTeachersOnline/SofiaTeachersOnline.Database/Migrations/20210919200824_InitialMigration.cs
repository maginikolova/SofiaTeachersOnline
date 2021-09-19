using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SofiaTeachersOnline.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WannaBeUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNr = table.Column<string>(nullable: true),
                    RecordedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WannaBeUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "CourseProgresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Progress = table.Column<float>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProgresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    LastOnline = table.Column<DateTime>(nullable: false),
                    ProfilePic = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    NumberOfSales = table.Column<int>(nullable: true),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    SalesAgentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedLink_AspNetUsers_SalesAgentId",
                        column: x => x.SalesAgentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notebooks_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notebooks_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    GivenById = table.Column<Guid>(nullable: false),
                    GivenToId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_GivenById",
                        column: x => x.GivenById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_GivenToId",
                        column: x => x.GivenToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Mark = table.Column<byte>(nullable: false),
                    TeacherId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedByUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_AspNetUsers_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Grades_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LastOnline", "LockoutEnabled", "LockoutEnd", "ModifiedByUserId", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePic", "SecurityStamp", "TwoFactorEnabled", "UserName", "CourseId" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4201-8b43-cecc2d404270"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0a468797-7cd9-47f7-8d9e-ec850936dbdd", new DateTime(2021, 9, 19, 20, 8, 23, 752, DateTimeKind.Utc).AddTicks(2380), null, "Student", "magi@mail.com", false, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEGIyz5BJ9FPSnq1R/KeVlS1l6aZu0EP1yLlzwPaax2FcrmxUNIjsMhtzsYl0GrTqjg==", "0886868686", false, null, "7dfee30b-3054-44cd-a371-93d1c64a1820", false, "magi@mail.com", null },
                    { new Guid("71c88aa4-b6b6-45e8-0ea1-ba1912c1a845"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b368da8d-6e61-49a4-9137-df70c8fa4c3a", new DateTime(2021, 9, 19, 20, 8, 23, 752, DateTimeKind.Utc).AddTicks(8316), null, "Student", "phresli@mail.com", false, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, "PHRESLI@MAIL.COM", "PHRESLI@MAIL.COM", "AQAAAAEAACcQAAAAEEhu0twTtyZO+GGW2VL/BgFvUb7IEAw9OP+cpI1UUm09g5o1oWGbvobHW3m2dvxBCA==", "0886868688", false, null, "c4265f10-9d54-45ee-8d76-0daf7e1e1d19", false, "phresli@mail.com", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LastOnline", "LockoutEnabled", "LockoutEnd", "ModifiedByUserId", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePic", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bda04f93-b5da-44da-aa7d-f35ece39d2c2", new DateTime(2021, 9, 19, 20, 8, 23, 787, DateTimeKind.Utc).AddTicks(1450), null, "Teacher", "magin@mail.com", false, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, "MAGINMAIL@MAIL.COM", "MAGIN@MAIL.COM", "AQAAAAEAACcQAAAAEP3NcOUHi+zn4ddlIDQkiRZpwx7AVt523Ln4X89ydCPX8sQD0SbFJkKxgI0J6nh4BQ==", "0889868686", false, null, "340e9eeb-c26e-4c42-83bc-4215377821af", false, "magin@mail.com" },
                    { new Guid("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b05ae53b-bd5f-4950-9982-51a6b9e668ac", new DateTime(2021, 9, 19, 20, 8, 23, 787, DateTimeKind.Utc).AddTicks(1682), null, "Teacher", "phreslip@mail.com", false, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, "PHRESLIP@MAIL.COM", "PHRESLIP@MAIL.COM", "AQAAAAEAACcQAAAAEFNl24YpIDlRzfsCTJ0rsN64AESvo7WfPmLUvj1X6eP3Fa52By9xg9x7iEfmh+PHPA==", "0812868688", false, null, "3dcd28fb-5fc6-478a-9c6b-2c8b274769fd", false, "phreslip@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn", "StudentId", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(3775), null, false, null, null, null, new Guid("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845"), "10-те най-чести грешки в английския" },
                    { 2, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(5915), null, false, null, null, null, new Guid("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845"), "Общ английски" },
                    { 3, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(5969), null, false, null, null, null, new Guid("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845"), "Бизнес Английски" },
                    { 4, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(5974), null, false, null, null, null, new Guid("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845"), "Подготовка за сертификат" },
                    { 5, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(5978), null, false, null, null, null, new Guid("71c88cc4-b6b6-45e8-9ea1-ba1912c1a845"), "Български за чужденци" }
                });

            migrationBuilder.InsertData(
                table: "CourseProgresses",
                columns: new[] { "Id", "CourseId", "CreatedOn", "DeletedOn", "IsDeleted", "Progress", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(7554), null, false, 10f, new Guid("1d6e3bae-451f-4201-8b43-cecc2d404270") },
                    { 2, 2, new DateTime(2021, 9, 19, 20, 8, 23, 812, DateTimeKind.Utc).AddTicks(9489), null, false, 20f, new Guid("71c88aa4-b6b6-45e8-0ea1-ba1912c1a845") }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Content", "CourseId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedByUserId", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "some content", 1, new DateTime(2021, 9, 19, 20, 8, 23, 813, DateTimeKind.Utc).AddTicks(1426), null, false, null, null },
                    { 2, "some content2", 2, new DateTime(2021, 9, 19, 20, 8, 23, 813, DateTimeKind.Utc).AddTicks(2539), null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "ExerciseId", "IsDeleted", "Mark", "ModifiedByUserId", "ModifiedOn", "StudentId", "TeacherId" },
                values: new object[] { 2, new DateTime(2021, 9, 19, 20, 8, 23, 813, DateTimeKind.Utc).AddTicks(6153), null, 1, false, (byte)6, null, null, new Guid("1d6e3bae-451f-4201-8b43-cecc2d404270"), new Guid("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845") });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "ExerciseId", "IsDeleted", "Mark", "ModifiedByUserId", "ModifiedOn", "StudentId", "TeacherId" },
                values: new object[] { 1, new DateTime(2021, 9, 19, 20, 8, 23, 813, DateTimeKind.Utc).AddTicks(4050), null, 2, false, (byte)4, null, null, new Guid("1d6e3bae-451f-4201-8b43-cecc2d404270"), new Guid("71c88bb4-b6b6-45e8-9ea1-ba1912c1a845") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_ModifiedByUserId",
                table: "AspNetUsers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CourseId",
                table: "AspNetUsers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgresses_CourseId",
                table: "CourseProgresses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProgresses_StudentId",
                table: "CourseProgresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ModifiedByUserId",
                table: "Courses",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CourseId",
                table: "Exercises",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ModifiedByUserId",
                table: "Exercises",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedLink_SalesAgentId",
                table: "GeneratedLink",
                column: "SalesAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ExerciseId",
                table: "Grades",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ModifiedByUserId",
                table: "Grades",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_ModifiedByUserId",
                table: "Notebooks",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_StudentId",
                table: "Notebooks",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_GivenById",
                table: "Ratings",
                column: "GivenById");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_GivenToId",
                table: "Ratings",
                column: "GivenToId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CourseId",
                table: "Videos",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ModifiedByUserId",
                table: "Videos",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgresses_AspNetUsers_StudentId",
                table: "CourseProgresses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseProgresses_Courses_CourseId",
                table: "CourseProgresses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_ModifiedByUserId",
                table: "Courses",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_StudentId",
                table: "Courses",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_ModifiedByUserId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_StudentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses");

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
                name: "CourseProgresses");

            migrationBuilder.DropTable(
                name: "GeneratedLink");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "WannaBeUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
