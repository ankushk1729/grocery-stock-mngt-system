
namespace GSMS {
    class Init {

        public static void Main(string[] args)
        {
            RecipeActions.showAllRecipes();
            StockActions.showQuantities();
            RecipeActions.showRecipesThatContainsItem("rice");

            var menu = new Menu();
            menu.showMenu();
        }
    }
}
