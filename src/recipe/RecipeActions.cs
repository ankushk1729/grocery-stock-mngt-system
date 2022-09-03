namespace GSMS 
{
    class RecipeActions
    {
        public static void showAllRecipes(){
            var allRecipes = Recipe.getAllRecipes();
            
            showRecipes(allRecipes);
        }

        public static void showRecipe(string recipeName){
            var recipe = Recipe.getRecipe(recipeName);
            System.Console.WriteLine($"{recipeName} : ");
            Util.printTable(recipe);
        }

        public static void showRecipes(Dictionary<string, Dictionary<string, int>> recipes){
            foreach(KeyValuePair<string, Dictionary<string, int>> recipe in recipes){
                System.Console.WriteLine($"{recipe.Key}'s recipe : ");
                Util.printTable(recipe.Value);
            }
        }

        public static void showRecipesThatContainsItem(string recipeName){
            var recipes = Recipe.getRecipesThatContainsItem(recipeName);

            if(recipes.Count < 1){
                System.Console.WriteLine($"\nNo recipes found that contains {recipeName} \n");
            }

            RecipeActions.showRecipes(recipes);
        }
    }
}