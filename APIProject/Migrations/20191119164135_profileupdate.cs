using Microsoft.EntityFrameworkCore.Migrations;

namespace APIProject.Migrations
{
    public partial class profileupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "LawyerProfile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "ClientProfile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LawyerProfile_UsersId",
                table: "LawyerProfile",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfile_UsersId",
                table: "ClientProfile",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfile_Users_UsersId",
                table: "ClientProfile",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LawyerProfile_Users_UsersId",
                table: "LawyerProfile",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfile_Users_UsersId",
                table: "ClientProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LawyerProfile_Users_UsersId",
                table: "LawyerProfile");

            migrationBuilder.DropIndex(
                name: "IX_LawyerProfile_UsersId",
                table: "LawyerProfile");

            migrationBuilder.DropIndex(
                name: "IX_ClientProfile_UsersId",
                table: "ClientProfile");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "LawyerProfile");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ClientProfile");
        }
    }
}
