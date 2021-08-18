using Microsoft.EntityFrameworkCore.Migrations;

namespace Gymate.Infrastructure.Migrations
{
    public partial class ExerciseWithoutLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "DayOfWeekId",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "LoadInKg",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Sets",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Routines",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoadForExercise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sets = table.Column<int>(nullable: false),
                    Reps = table.Column<int>(nullable: false),
                    LoadInKg = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadForExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadForExercise_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadForExercise_ExerciseId",
                table: "LoadForExercise",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadForExercise");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Routines");

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "Routines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeekId",
                table: "Routines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoadInKg",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
