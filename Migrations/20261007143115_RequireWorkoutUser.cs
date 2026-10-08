using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NEA_Rowing_Calculation_Website.Migrations
{
    /// <inheritdoc />
    public partial class RequireWorkoutUser : Migration
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_UserID",
                table: "Workouts",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
