using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Postgresdb.Migrations
{
    /// <inheritdoc />
    public partial class modify_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientsInRecipes_IngredientId",
                table: "IngredientsInRecipes");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInRecipes_IngredientId",
                table: "IngredientsInRecipes",
                column: "IngredientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IngredientsInRecipes_IngredientId",
                table: "IngredientsInRecipes");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInRecipes_IngredientId",
                table: "IngredientsInRecipes",
                column: "IngredientId");
        }
    }
}
