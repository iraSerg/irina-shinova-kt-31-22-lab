using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShinovaIrinaKt3122.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_degree",
                columns: table => new
                {
                    degreeid = table.Column<int>(name: "degree_id", type: "integer", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdegreename = table.Column<string>(name: "c_degree_name", type: "varchar", maxLength: 50, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_degree_degree_id", x => x.degreeid);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    positionid = table.Column<int>(name: "position_id", type: "integer", nullable: false, comment: "Идентификатор должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cpositionname = table.Column<string>(name: "c_position_name", type: "varchar", maxLength: 50, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.positionid);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    departmentid = table.Column<int>(name: "department_id", type: "integer", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cdepartmentname = table.Column<string>(name: "c_department_name", type: "varchar", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    HeadId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.departmentid);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacherid = table.Column<int>(name: "teacher_id", type: "integer", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cteacherfirstname = table.Column<string>(name: "c_teacher_firstname", type: "varchar", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    cteacherlastname = table.Column<string>(name: "c_teacher_lastname", type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    cteachermiddlename = table.Column<string>(name: "c_teacher_middlename", type: "varchar", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    DegreeId = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacherid);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "cd_degree",
                        principalColumn: "degree_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cd_teacher_cd_position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cd_load",
                columns: table => new
                {
                    loadid = table.Column<int>(name: "load_id", type: "integer", nullable: false, comment: "Идентификатор нагрузки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    cloadhours = table.Column<int>(name: "c_load_hours", type: "int4", nullable: false, comment: "Количество часов нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_load_load_id", x => x.loadid);
                    table.ForeignKey(
                        name: "FK_cd_load_cd_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subjectid = table.Column<int>(name: "subject_id", type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    csubjectname = table.Column<string>(name: "c_subject_name", type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    TeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subjectid);
                    table.ForeignKey(
                        name: "FK_cd_subject_cd_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_department_HeadId",
                table: "cd_department",
                column: "HeadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cd_load_TeacherId",
                table: "cd_load",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_subject_TeacherId",
                table: "cd_subject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_DegreeId",
                table: "cd_teacher",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_DepartmentId",
                table: "cd_teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_PositionId",
                table: "cd_teacher",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_cd_department_cd_teacher_HeadId",
                table: "cd_department",
                column: "HeadId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cd_department_cd_teacher_HeadId",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_load");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
