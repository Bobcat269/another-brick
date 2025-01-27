using System.ComponentModel.DataAnnotations;

namespace PantryWebApp.Models
{
    public class RecipeIngredient
    {
        //bridge table between Recipe and Ingredient
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public Recipe Recipe { get; set; }  //Navigates to Recipe

        [Required]
        public int IngredientId { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; } //Nav to Ingredient
    }
}
