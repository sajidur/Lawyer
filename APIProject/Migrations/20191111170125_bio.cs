using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProject.Migrations
{
    public partial class bio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "LawyerProfile");

            migrationBuilder.CreateTable(
                name: "BIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    biotext = table.Column<string>(nullable: true),
                    LawyerProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BIO_LawyerProfile_LawyerProfileId",
                        column: x => x.LawyerProfileId,
                        principalTable: "LawyerProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BIO_LawyerProfileId",
                table: "BIO",
                column: "LawyerProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BIO");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "LawyerProfile",
                nullable: true);
        }
    }
}
