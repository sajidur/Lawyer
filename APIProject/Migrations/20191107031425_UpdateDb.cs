using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProject.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ClientProfile");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "LawyerProfile",
                newName: "WorkingArea");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "LawyerProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "LawyerProfile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BioCharLimit",
                table: "LawyerProfile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LawChamberId",
                table: "LawyerProfile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageSettingsId",
                table: "LawyerProfile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfilePicId",
                table: "LawyerProfile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ClientProfile",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Division = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Thana = table.Column<string>(nullable: true),
                    FullAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DegreeName = table.Column<string>(nullable: true),
                    Passyear = table.Column<string>(nullable: true),
                    InstituteName = table.Column<string>(nullable: true),
                    Order = table.Column<string>(nullable: true),
                    LawyerProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_LawyerProfile_LawyerProfileId",
                        column: x => x.LawyerProfileId,
                        principalTable: "LawyerProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    ExperienceArea = table.Column<string>(nullable: true),
                    FromDate = table.Column<long>(nullable: false),
                    ToDate = table.Column<long>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    LawyerProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_LawyerProfile_LawyerProfileId",
                        column: x => x.LawyerProfileId,
                        principalTable: "LawyerProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UploadType = table.Column<int>(nullable: false),
                    FileContent = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Package = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LawChambers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ChamberName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    PackageSettingsId = table.Column<int>(nullable: true),
                    ChamberHeadId = table.Column<int>(nullable: true),
                    AssociatesLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawChambers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawChambers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawChambers_Users_ChamberHeadId",
                        column: x => x.ChamberHeadId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LawChambers_PackageSettings_PackageSettingsId",
                        column: x => x.PackageSettingsId,
                        principalTable: "PackageSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LawyerProfile_AddressId",
                table: "LawyerProfile",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerProfile_LawChamberId",
                table: "LawyerProfile",
                column: "LawChamberId");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerProfile_PackageSettingsId",
                table: "LawyerProfile",
                column: "PackageSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerProfile_ProfilePicId",
                table: "LawyerProfile",
                column: "ProfilePicId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfile_AddressId",
                table: "ClientProfile",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_LawyerProfileId",
                table: "Education",
                column: "LawyerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_LawyerProfileId",
                table: "Experience",
                column: "LawyerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_LawChambers_AddressId",
                table: "LawChambers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_LawChambers_ChamberHeadId",
                table: "LawChambers",
                column: "ChamberHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LawChambers_PackageSettingsId",
                table: "LawChambers",
                column: "PackageSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfile_Address_AddressId",
                table: "ClientProfile",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerProfile_Address_AddressId",
                table: "LawyerProfile",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerProfile_LawChambers_LawChamberId",
                table: "LawyerProfile",
                column: "LawChamberId",
                principalTable: "LawChambers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerProfile_PackageSettings_PackageSettingsId",
                table: "LawyerProfile",
                column: "PackageSettingsId",
                principalTable: "PackageSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerProfile_FileAttachment_ProfilePicId",
                table: "LawyerProfile",
                column: "ProfilePicId",
                principalTable: "FileAttachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfile_Address_AddressId",
                table: "ClientProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerProfile_Address_AddressId",
                table: "LawyerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerProfile_LawChambers_LawChamberId",
                table: "LawyerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerProfile_PackageSettings_PackageSettingsId",
                table: "LawyerProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerProfile_FileAttachment_ProfilePicId",
                table: "LawyerProfile");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "FileAttachment");

            migrationBuilder.DropTable(
                name: "LawChambers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PackageSettings");

            migrationBuilder.DropIndex(
                name: "IX_LawyerProfile_AddressId",
                table: "LawyerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LawyerProfile_LawChamberId",
                table: "LawyerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LawyerProfile_PackageSettingsId",
                table: "LawyerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LawyerProfile_ProfilePicId",
                table: "LawyerProfile");

            migrationBuilder.DropIndex(
                name: "IX_ClientProfile_AddressId",
                table: "ClientProfile");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "BioCharLimit",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "LawChamberId",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "PackageSettingsId",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "ProfilePicId",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ClientProfile");

            migrationBuilder.RenameColumn(
                name: "WorkingArea",
                table: "LawyerProfile",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ClientProfile",
                nullable: true);
        }
    }
}
