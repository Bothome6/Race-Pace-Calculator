using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEA_Rowing_Calculation_Website.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Workouts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<bool>(
                name: "Abandoned",
                table: "Workouts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TwoKSplit",
                table: "Workouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    WorkoutSessionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkoutID = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TaskDescription = table.Column<string>(type: "TEXT", nullable: false),
                    PlannedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    DoneDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.WorkoutSessionID);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Workouts_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutID",
                table: "WorkoutSessions",
                column: "WorkoutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "Abandoned",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TwoKSplit",
                table: "Workouts");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Workouts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
