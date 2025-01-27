namespace PantryWebApp.Models
{
    public class Ingredient
    {
        //? is the way we allow fields to be nullable (not required)
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Quantity { get; set; }

        //public DateOnly? Expiration {  get; set; }  //For whatever reason, DateOnly? does not work so we will use DateTime and hide the Time
        public DateTime? Expiration { get; set; }

        //pretty cool, upon changing date to datetime we didn't lose any data baby!!!!

        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();


        //Constructor
        public Ingredient()
        {
            
        }
    }
}

