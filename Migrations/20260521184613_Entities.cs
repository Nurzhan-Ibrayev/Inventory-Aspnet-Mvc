using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ItransitionProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CreatorId = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CustomString1Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomString1State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomString2Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomString2State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomString3Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomString3State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomMultiline1Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomMultiline1State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomMultiline2Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomMultiline2State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomMultiline3Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomMultiline3State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomInt1Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomInt1State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomInt2Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomInt2State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomInt3Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomInt3State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomBool1Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomBool1State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomBool2Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomBool2State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomBool3Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomBool3State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomLink1Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomLink1State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomLink2Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomLink2State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CustomLink3Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CustomLink3State = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAccesses",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    GrantedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAccesses", x => new { x.InventoryId, x.UserId });
                    table.ForeignKey(
                        name: "FK_InventoryAccesses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryAccesses_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    CustomId = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedById = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    CustomString1Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CustomString2Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CustomString3Value = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    CustomMultiline1Value = table.Column<string>(type: "text", nullable: true),
                    CustomMultiline2Value = table.Column<string>(type: "text", nullable: true),
                    CustomMultiline3Value = table.Column<string>(type: "text", nullable: true),
                    CustomInt1Value = table.Column<double>(type: "double precision", nullable: true),
                    CustomInt2Value = table.Column<double>(type: "double precision", nullable: true),
                    CustomInt3Value = table.Column<double>(type: "double precision", nullable: true),
                    CustomBool1Value = table.Column<bool>(type: "boolean", nullable: true),
                    CustomBool2Value = table.Column<bool>(type: "boolean", nullable: true),
                    CustomBool3Value = table.Column<bool>(type: "boolean", nullable: true),
                    CustomLink1Value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CustomLink2Value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CustomLink3Value = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTags",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTags", x => new { x.InventoryId, x.TagId });
                    table.ForeignKey(
                        name: "FK_InventoryTags_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.ItemId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_InventoryId",
                table: "Comments",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CategoryId",
                table: "Inventories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CreatorId",
                table: "Inventories",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_FullText",
                table: "Inventories",
                columns: new[] { "Title", "Description" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAccesses_UserId",
                table: "InventoryAccesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTags_TagId",
                table: "InventoryTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatedById",
                table: "Items",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "UX_Items_InventoryId_CustomId",
                table: "Items",
                columns: new[] { "InventoryId", "CustomId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "InventoryAccesses");

            migrationBuilder.DropTable(
                name: "InventoryTags");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
