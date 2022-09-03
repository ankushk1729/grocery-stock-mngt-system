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
            // Stock.printQuantities();

            // Stock.addItem("lichi");
            // Stock.addItem("lemon", 5);
            // Stock.deleteItem("onion");

            // var pastaRecipe = Recipe.getRecipe("pasta");
            // var allRecipes = Recipe.getAllRecipes();
            
            // Recipe.printRecipe("maggi");
            // Recipe.printAllRecipes();
            // var friedRiceItems = new Dictionary<string, int>(){
            //     {"rice", 1},
            //     {"onion", 1}
            // };

            // Recipe.createRecipe("friedRice", friedRiceItems);
            Recipe.printAllRecipes();

            // System.Console.WriteLine( Recipe.useRecipe("friedRice"));

            // Recipe.deleteRecipe("pasta");

            // System.Console.WriteLine(Recipe.updateRecipe("friedRice", new Dictionary<string, int>(){{"onion", 7}, {"water", 2}}));

            Stock.printQuantities();


        }
    }
}
