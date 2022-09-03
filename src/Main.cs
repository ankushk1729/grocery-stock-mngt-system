// See https://aka.ms/new-console-template for more information

namespace GSMS {
    class Init {

        public static void Main(string[] args)
        {
            // Stock.increaseQuantityOfItem("guava", 4);

            // Stock.printQuantityOfAnItem("guava");
            Stock.printQuantities();

            // Stock.decreaseQuantityOfItem("guava", 4);
            // Stock.updateQuantityOfItem("tomato", 7);
            Stock.printQuantities();

            Stock.addItem("lichi");
            Stock.addItem("lemon", 5);
            Stock.deleteItem("onion");
            Stock.printQuantities();

            var pastaRecipe = Recipe.getRecipe("pasta");
            var allRecipes = Recipe.getAllRecipes();
            
            // Recipe.printAllRecipes();
            Recipe.printRecipe("maggi");
        }
    }
}
