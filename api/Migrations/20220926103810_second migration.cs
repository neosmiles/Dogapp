using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Dogs_DogId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_DogId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Breeds");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs",
                column: "BreedId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Breeds_BreedId",
                table: "Dogs",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Breeds_BreedId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Breeds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_DogId",
                table: "Breeds",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Dogs_DogId",
                table: "Breeds",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
