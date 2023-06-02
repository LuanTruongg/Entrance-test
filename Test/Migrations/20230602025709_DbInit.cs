using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Female = table.Column<bool>(type: "bit", nullable: false),
                    Born = table.Column<int>(type: "int", nullable: false),
                    Died = table.Column<int>(type: "int", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "Born", "Died", "Female", "Name", "age" },
                values: new object[,]
                {
                    { 1, 1957, null, false, "Steve Harvey", 0 },
                    { 2, 1864, 1912, false, "James Allen", 0 },
                    { 3, 1945, null, true, "Robin Norwood", 0 },
                    { 4, 1982, null, false, "Ramit Sethi", 0 },
                    { 5, 1948, null, true, "Melody Beattie", 0 },
                    { 6, 1888, 1955, true, "Dale Carnegie", 0 },
                    { 7, 1940, null, false, "Wayne Dyer", 0 },
                    { 8, 1937, null, false, "John T. Molloy", 0 },
                    { 10, 1934, 2006, false, "Allen Carr", 0 },
                    { 12, 1959, null, false, "Robert Greene", 0 },
                    { 13, 1949, null, true, "Wendy Kaminer", 0 },
                    { 14, 1927, 1987, false, "David Schwartz", 0 },
                    { 15, 1964, null, false, "Robin Sharma", 0 },
                    { 16, 1898, 1993, false, "Norman Vincent Peale", 0 },
                    { 17, 1899, 1975, false, "Maxwell Maltz", 0 },
                    { 18, 1951, null, true, "Rhonda Byrne", 0 },
                    { 19, 1932, 2012, false, "Stephen Covey", 0 },
                    { 20, 1883, 1970, false, "Napoleon Hill", 0 },
                    { 21, 1960, null, false, "Anthony Robbins", 0 },
                    { 22, 1926, 2017, true, "Louise Hay", 0 },
                    { 23, 1926, 1949, false, "Charles F.Haanel", 0 },
                    { 24, 1948, null, false, "Eckhart Tolle", 0 },
                    { 25, 1950, null, true, "Diane Muldrow", 0 },
                    { 26, 1957, null, false, "David Gillespie", 0 },
                    { 27, 1968, null, false, "Burra Venkatesham", 0 },
                    { 28, 1955, null, false, "Dr.Walter Doyle Staples", 0 },
                    { 29, 1925, 2021, false, "Wahiduddin Khan", 0 },
                    { 30, 1947, null, false, "Paulo Coelho", 0 }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "AuthorName", "Price", "PublishYear", "Rating", "Title", "Topic" },
                values: new object[,]
                {
                    { 1, 1, "Steve Harvey", 20m, 2009, 1, "Act like a Lady, Think like a Man", "relationship" },
                    { 2, 2, "James Allen", 50m, 1902, 2, "As a Man Thinketh", "positive thinking" },
                    { 3, 3, "Robin Norwood", 15.4m, 1985, 3, "Women Who Love Too Much", "relationship" },
                    { 4, 4, "Ramit Sethi", 20m, 2009, 4, "I Will Teach You To Be Rich", "success" },
                    { 5, 5, "Melody Beattie", 32m, 1986, 2, "Codependent No More", "relationship" },
                    { 6, 6, "Dale Carnegie", 50m, 1948, 4, "How to Stop Worrying and Start Living", "optimism" },
                    { 7, 7, "Wayne Dyer", 24m, 1976, 5, "Your Erroneous Zones", "health" },
                    { 8, 8, "John T. Molloy", 54.2m, 1975, 3, "Dress for Success", "success" },
                    { 9, 10, "Allen Carr", 45.6m, 2006, 2, "The Easy Way to Stop Smoking", "health" },
                    { 10, 6, "Dale Carnegie", 10.2m, 1936, 4, "How to Win Friends and Influence People", "success" },
                    { 11, 10, "Allen Carr", 20.5m, 1985, 2, "The 48 Laws of Power", "success" },
                    { 12, 12, "Robert Greene", 10.05m, 1998, 3, "I'm Dysfunctional, You're Dysfunctional", "anti-self-help" },
                    { 13, 12, "Robert Greene", 100m, 1992, 5, "The Magic of Thinking Big", "success" },
                    { 14, 13, "Wendy Kaminer", 39.55m, 1959, 3, "The Monk Who Sold His Ferrari", "health" },
                    { 15, 14, "David Schwartz", 12.34m, 1952, 5, "The Power of Positive Thinking", "optimism" },
                    { 16, 15, "Robin Sharma", 12.34m, 1960, 2, "Psycho-Cybernetics", "self image" },
                    { 17, 16, "Norman Vincent Peale", 20.5m, 2006, 4, "The Secret", "optimism" },
                    { 18, 17, "Maxwell Maltz", 50.3m, 1989, 1, "The Seven Habits of Highly Effective People", "success" },
                    { 19, 18, "Rhonda Byrne", 25.5m, 1937, 5, "Think and Grow Rich", "success" },
                    { 20, 19, "Stephen Covey", 20.5m, 1986, 5, "Unlimited Power", "success" },
                    { 21, 20, "Napoleon Hill", 100m, 1984, 4, "You Can Heal Your Life", "health" },
                    { 22, 21, "Anthony Robbins", 69.6m, 1916, 1, "The Master Key System", "optimism" },
                    { 23, 22, "Louise Hay", 45.56m, 1997, 4, "The Power of Now", "optimism" },
                    { 24, 18, "Rhonda Byrne", 100.05m, 1930, 5, "The Magic Ladder To Success", "" },
                    { 25, 18, "Rhonda Byrne", 32.45m, 2011, 3, "Outwitting the Devil", "success" },
                    { 26, 25, "Rhonda Byrne", 20.6m, 2019, 4, "Selfie Of Success", "success" },
                    { 27, 26, "Rhonda Byrne", 20.5m, 1991, 3, "Think Like a Winner!", "optimism" },
                    { 28, 27, "Burra Venkatesham", 14.3m, 1987, 5, "Raaz-e-Hayat", "optimism" }
                });

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
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
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
                name: "Book");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
