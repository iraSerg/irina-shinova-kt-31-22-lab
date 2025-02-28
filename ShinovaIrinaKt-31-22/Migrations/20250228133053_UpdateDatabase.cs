using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShinovaIrinaKt3122.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_department_cd_teacher_HeadId",
                table: "cd_department");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_department_cd_teacher_HeadId",
                table: "cd_department",
                column: "HeadId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_department_cd_teacher_HeadId",
                table: "cd_department");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_department_cd_teacher_HeadId",
                table: "cd_department",
                column: "HeadId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
