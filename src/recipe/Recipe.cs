

namespace GSMS
{
    class Recipe
    {
        // Getters
        public static Dictionary<string, Dictionary<string, int>> getAllRecipes(){
            var data = Json.readFromJson();

            return data.recipes;
        }

        public static KeyValuePair<bool, Dictionary<string, int>> getRecipe(string recipeName){
            var data = Json.readFromJson();
            if(!data.recipes.ContainsKey(recipeName)){
                return new KeyValuePair<bool, Dictionary<string, int>>(false, new Dictionary<string, int>());
            }

            return new KeyValuePair<bool, Dictionary<string, int>>(true, data.recipes[recipeName]);
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

        public static Tuple<bool, Dictionary<string, int>, Dictionary<string, int>> useRecipe(string recipeName, int servings = 1){
            var data = Json.readFromJson();
            Dictionary<string, int> nonExistingItems = new Dictionary<string, int>();
            Dictionary<string, int> insufficientItems = new Dictionary<string, int>();

            var recipe = data.recipes[recipeName];

            foreach(KeyValuePair<string, int> item in recipe){
                if(!Stock.checkContainsItem(item.Key)){
                    nonExistingItems.Add(item.Key, item.Value);
                    continue;
                }
                 if(data.stock[item.Key] < servings*item.Value){
                    insufficientItems.Add(item.Key, item.Value);
                }
            }

            if(insufficientItems.Count > 0 || nonExistingItems.Count > 0){
                return new Tuple<bool, Dictionary<string, int>, Dictionary<string, int>>(false, nonExistingItems, insufficientItems);
            }

            foreach(KeyValuePair<string, int> item in recipe){
                data.stock[item.Key] -= servings*item.Value;
            }

            Json.writeToJson(data);
            return new Tuple<bool, Dictionary<string, int>, Dictionary<string, int>>(true, insufficientItems, nonExistingItems);
        }
    }
}