﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PantryWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class integratingRecipeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredient");
        }
    }
}
