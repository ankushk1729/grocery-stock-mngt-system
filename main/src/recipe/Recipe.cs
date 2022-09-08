

namespace GSMS
{
    public class Recipe
    {
        private IJson json;
        private Stock _stock;
        public Recipe(IJson Json){
            json = Json;
            _stock = new Stock(json);
        }
        // Getters
        public Dictionary<string, Dictionary<string, int>> getAllRecipes(){
            var data = json.readFromJson();

            return data.recipes;
        }

        public KeyValuePair<bool, Dictionary<string, int>> getRecipe(string recipeName){
            var data = json.readFromJson();
            if(!data.recipes.ContainsKey(recipeName)){
                return new KeyValuePair<bool, Dictionary<string, int>>(false, new Dictionary<string, int>());
            }

            return new KeyValuePair<bool, Dictionary<string, int>>(true, data.recipes[recipeName]);
        }

        public bool checkContainsRecipe(string recipeName){
            var data = json.readFromJson();
            
            return data.recipes.ContainsKey(recipeName);
        }

        public Dictionary<string, Dictionary<string, int>> getRecipesThatContainsItem(string itemName){
            var data = json.readFromJson();

            Dictionary<string, Dictionary<string, int>> filtered = data.recipes.Where(recipe => recipe.Value.ContainsKey(itemName)).ToDictionary(recipe => recipe.Key, recipe => recipe.Value);

            return filtered;
        }

        

        // Updations

        public void createRecipe(string recipeName, Dictionary<string, int> items){
            var data = json.readFromJson();

            data.recipes.Add(recipeName, items);

            json.writeToJson(data);
        }

        public bool deleteRecipe(string recipeName){
            var data = json.readFromJson();
            if(!checkContainsRecipe(recipeName)){
                return false;
            }
            data.recipes.Remove(recipeName);
            json.writeToJson(data);

            return true;
        }

        public bool updateRecipe(string recipeName, Dictionary<string, int> items){
            if(!checkContainsRecipe(recipeName)){
                return false;
            }

            var data = json.readFromJson();
            foreach(KeyValuePair<string, int> item in items){
                if(!data.recipes[recipeName].ContainsKey(item.Key)){
                    data.recipes[recipeName].Add(item.Key, item.Value);
                }
                else {
                    data.recipes[recipeName][item.Key] = item.Value;
                }
            }
            json.writeToJson(data);
            return true;
        }

        public Tuple<bool, Dictionary<string, int>, Dictionary<string, int>> useRecipe(string recipeName, int servings = 1){
            var data = json.readFromJson();
            Dictionary<string, int> nonExistingItems = new Dictionary<string, int>();
            Dictionary<string, int> insufficientItems = new Dictionary<string, int>();

            var recipe = data.recipes[recipeName];

            foreach(KeyValuePair<string, int> item in recipe){
                if(!_stock.checkContainsItem(item.Key)){
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

            json.writeToJson(data);
            return new Tuple<bool, Dictionary<string, int>, Dictionary<string, int>>(true, insufficientItems, nonExistingItems);
        }
    }
}