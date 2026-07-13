using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DogGo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    NeighborhoodId = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Walkers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NeighborhoodId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walkers_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Breed = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DogId = table.Column<int>(type: "integer", nullable: false),
                    WalkerId = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Walkers_WalkerId",
                        column: x => x.WalkerId,
                        principalTable: "Walkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Neighborhoods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "East Nashville" },
                    { 2, "Antioch" },
                    { 3, "Berry Hill" },
                    { 4, "Germantown" },
                    { 5, "The Gulch" },
                    { 6, "Downtown" },
                    { 7, "Music Row" },
                    { 8, "Hermitage" },
                    { 9, "Madison" },
                    { 10, "Green Hills" },
                    { 11, "Midtown" },
                    { 12, "West Nashville" },
                    { 13, "Donelson" },
                    { 14, "North Nashville" },
                    { 15, "Belmont-Hillsboro" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Email", "Name", "NeighborhoodId", "Phone" },
                values: new object[,]
                {
                    { 1, "355 Main St", "john@gmail.com", "John Sanchez", 1, "(615)-553-2456" },
                    { 2, "355 Main St", "patty@gmail.com", "Patricia Young", 2, "(615)-553-2456" },
                    { 3, "355 Main St", "robert@gmail.com", "Robert Brown", 3, "(615)-553-2456" },
                    { 4, "355 Main St", "jennifer@gmail.com", "Jennifer Wilson", 1, "(615)-553-2456" },
                    { 5, "355 Main St", "michael@gmail.com", "Michael Moore", 2, "(615)-553-2456" },
                    { 6, "355 Main St", "linda@gmail.com", "Linda Green", 3, "(615)-553-2456" },
                    { 7, "355 Main St", "william@gmail.com", "William Anderson", 1, "(615)-553-2456" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Breed", "ImageUrl", "Name", "Notes", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Rottweiler", null, "Ninni", null, 1 },
                    { 2, "Rottweiler", null, "Kuma", null, 1 },
                    { 3, "Greyhound", null, "Remy", null, 2 },
                    { 4, "Dalmation", null, "Xyla", null, 3 },
                    { 5, "Beagle", null, "Chewy", null, 3 },
                    { 6, "Dalmation", null, "Groucho", null, 4 },
                    { 7, "Golden Retriever", null, "Finley", null, 5 },
                    { 8, "Golden Retriever", null, "Casper", null, 6 },
                    { 9, "English Bulldog", null, "Bubba", null, 7 },
                    { 10, "Schnauzer", null, "Zeus", null, 7 }
                });

            migrationBuilder.InsertData(
                table: "Walkers",
                columns: new[] { "Id", "ImageUrl", "Name", "NeighborhoodId" },
                values: new object[,]
                {
                    { 1, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Claudelle", 15 },
                    { 2, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Roi", 9 },
                    { 3, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Shena", 10 },
                    { 4, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Gibb", 8 },
                    { 5, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Tammy", 6 },
                    { 6, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Rufe", 11 },
                    { 7, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Cassandry", 12 },
                    { 8, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Cully", 4 },
                    { 9, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Cully", 14 },
                    { 10, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Agnesse", 1 },
                    { 11, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Koo", 7 },
                    { 12, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Diana", 6 },
                    { 13, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Moreen", 7 },
                    { 14, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Sonni", 13 },
                    { 15, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Nadiya", 9 },
                    { 16, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Olag", 12 },
                    { 17, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Alasdair", 12 },
                    { 18, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Jo ann", 12 },
                    { 19, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Ewen", 6 },
                    { 20, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Andee", 5 },
                    { 21, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Sada", 12 },
                    { 22, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Tasia", 3 },
                    { 23, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Sherry", 5 },
                    { 24, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Witty", 6 },
                    { 25, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Ezekiel", 5 },
                    { 26, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Emmeline", 1 },
                    { 27, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Darrick", 9 },
                    { 28, "https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", "Redford", 14 }
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
                name: "IX_Dogs_OwnerId",
                table: "Dogs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Walkers_NeighborhoodId",
                table: "Walkers",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DogId",
                table: "Walks",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_WalkerId",
                table: "Walks",
                column: "WalkerId");
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
                name: "Walks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Walkers");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Neighborhoods");
        }
    }
}
