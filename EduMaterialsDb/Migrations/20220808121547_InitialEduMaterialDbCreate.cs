using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduMaterialsDb.Migrations
{
    public partial class InitialEduMaterialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "EduMaterialTypes",
                columns: table => new
                {
                    EduMaterialTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduMaterialTypes", x => x.EduMaterialTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EduMaterials",
                columns: table => new
                {
                    EduMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EduMaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    PublishDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduMaterials", x => x.EduMaterialId);
                    table.ForeignKey(
                        name: "FK_EduMaterials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EduMaterials_EduMaterialTypes_EduMaterialTypeId",
                        column: x => x.EduMaterialTypeId,
                        principalTable: "EduMaterialTypes",
                        principalColumn: "EduMaterialTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EduMaterialReviews",
                columns: table => new
                {
                    EduMaterialReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewScore = table.Column<int>(type: "int", nullable: false),
                    EduMaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduMaterialReviews", x => x.EduMaterialReviewId);
                    table.ForeignKey(
                        name: "FK_EduMaterialReviews_EduMaterials_EduMaterialId",
                        column: x => x.EduMaterialId,
                        principalTable: "EduMaterials",
                        principalColumn: "EduMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EduMaterialReviews_EduMaterialId",
                table: "EduMaterialReviews",
                column: "EduMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EduMaterials_AuthorId",
                table: "EduMaterials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_EduMaterials_EduMaterialTypeId",
                table: "EduMaterials",
                column: "EduMaterialTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduMaterialReviews");

            migrationBuilder.DropTable(
                name: "EduMaterials");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "EduMaterialTypes");
        }
    }
}
