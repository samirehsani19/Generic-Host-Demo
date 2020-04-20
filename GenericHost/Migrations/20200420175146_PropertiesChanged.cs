using Microsoft.EntityFrameworkCore.Migrations;

namespace GenericHost.Migrations
{
    public partial class PropertiesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actor_ActorID",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "ActorID",
                table: "Movie",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_ActorID",
                table: "Movie",
                newName: "IX_Movie_ActorId");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actor_ActorId",
                table: "Movie",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "ActorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actor_ActorId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Movie",
                newName: "ActorID");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_ActorId",
                table: "Movie",
                newName: "IX_Movie_ActorID");

            migrationBuilder.AlterColumn<int>(
                name: "ActorID",
                table: "Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actor_ActorID",
                table: "Movie",
                column: "ActorID",
                principalTable: "Actor",
                principalColumn: "ActorID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
