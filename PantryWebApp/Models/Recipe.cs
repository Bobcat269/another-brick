using System.ComponentModel.DataAnnotations;

namespace PantryWebApp.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        //
        [Required]
        public string Name { get; set; }

        //If you don't want to include System.ComponentModel.DataAnnotations
        //or you don't need to do runtime validation you can use compile-time
        //validation by writing....
        //public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public List<string> RecipeIngredients { get; set; } = new List<string>();
        //RecipeIngredients because it's a list?

        //Constructor
        public Recipe()
        {

        }
    }
}
