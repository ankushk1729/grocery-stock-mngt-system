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

        public static bool checkContainsRecipe(string recipeName){
            var data = Json.readFromJson();
            
            return data.recipes.ContainsKey(recipeName);
        }

        public static Dictionary<string, Dictionary<string, int>> getRecipesThatContainsItem(string itemName){
            var data = Json.readFromJson();

            Dictionary<string, Dictionary<string, int>> filtered = data.recipes.Where(recipe => recipe.Value.ContainsKey(itemName)).ToDictionary(recipe => recipe.Key, recipe => recipe.Value);

            return filtered;
        }

        // Loggers
        public static void printAllRecipes(){
            var allRecipes = Recipe.getAllRecipes();
            
            printRecipes(allRecipes);
        }

        public static void printRecipe(string recipeName){
            var recipe = getRecipe(recipeName);
            System.Console.WriteLine($"{recipeName} : ");
            Util.printTable(recipe);
        }

        public static void printRecipes(Dictionary<string, Dictionary<string, int>> recipes){
            foreach(KeyValuePair<string, Dictionary<string, int>> recipe in recipes){
                System.Console.WriteLine($"{recipe.Key}'s recipe : ");
                Util.printTable(recipe.Value);
            }
        }

        public static void printRecipesThatContainsItem(string recipeName){
            var recipes = Recipe.getRecipesThatContainsItem(recipeName);

            if(recipes.Count < 1){
                System.Console.WriteLine($"\nNo recipes found that contains {recipeName} \n");
            }

            Recipe.printRecipes(recipes);
        }

        // Updations

        public static void createRecipe(string recipeName, Dictionary<string, int> items){
            var data = Json.readFromJson();

            data.recipes.Add(recipeName, items);

            Json.writeToJson(data);
        }

        public static bool deleteRecipe(string recipeName){
            var data = Json.readFromJson();
            if(!Recipe.checkContainsRecipe(recipeName)){
                return false;
            }
            data.recipes.Remove(recipeName);
            Json.writeToJson(data);

            return true;
        }

        public static bool updateRecipe(string recipeName, Dictionary<string, int> items){
            if(!Recipe.checkContainsRecipe(recipeName)){
                return false;
            }

            var data = Json.readFromJson();
            foreach(KeyValuePair<string, int> item in items){
                if(!data.recipes[recipeName].ContainsKey(item.Key)){
                    data.recipes[recipeName].Add(item.Key, item.Value);
                }
                else {
                    data.recipes[recipeName][item.Key] = item.Value;
                }
            }
            Json.writeToJson(data);
            return true;
        }

        public static bool useRecipe(string recipeName, int servings = 1){
            var data = Json.readFromJson();

            var recipe = data.recipes[recipeName];

            foreach(KeyValuePair<string, int> item in recipe){
                if(!Stock.checkContainsItem(item.Key) || data.stock[item.Key] < servings*item.Value){
                    return false;
                }
            }

            foreach(KeyValuePair<string, int> item in recipe){
                data.stock[item.Key] -= servings*item.Value;
            }

            Json.writeToJson(data);

            return true;
        }
    }
}