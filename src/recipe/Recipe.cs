using System;

namespace GSMS
{
    class Recipe
    {
        // Getters
        public static Dictionary<string, Dictionary<string, int>> getAllRecipes(){
            var data = Json.readFromJson();

            return data.recipes;
        }

        public static Dictionary<string, int> getRecipe(string recipeName){
            var data = Json.readFromJson();

            return data.recipes[recipeName];
        }

        // Loggers
        public static void printAllRecipes(){
            var allRecipes = Recipe.getAllRecipes();
            
            foreach(KeyValuePair<string, Dictionary<string, int>> recipe in allRecipes){
                System.Console.WriteLine($"{recipe.Key}'s recipe : ");
                Util.printTable(recipe.Value);
            }
        }

        public static void printRecipe(string recipeName){
            var recipe = getRecipe(recipeName);
            System.Console.WriteLine($"{recipeName} : ");
            Util.printTable(recipe);
        }
    }
}