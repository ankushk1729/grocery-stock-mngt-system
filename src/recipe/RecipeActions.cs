namespace GSMS 
{
    class RecipeActions
    {

        // Utils
        public static Dictionary<string, int> takeRecipeInput(){
            Dictionary<string, int> recipeItems = new Dictionary<string, int>();
            while(true){
                System.Console.WriteLine("Enter Y to add more or N to finish");
                var input = Console.ReadKey();
                if(input.KeyChar == 'N'){
                    break;
                }
                System.Console.WriteLine("\n");
                while(true){
                    
                    string itemName;
                    int quantity;
                    try {
                        Console.WriteLine("Enter the name of item : ");
                        itemName = Console.ReadLine()!;
                        if(itemName == "") throw new FormatException();
                    }
                    catch(FormatException){
                        Log.error("Please enter alphabets only for item name");
                        continue;
                    }
                    try {
                        Console.WriteLine("Enter the quantity : ");
                        quantity = int.Parse(Console.ReadLine()!);
                        if(quantity <= 0) throw new FormatException();
                    }
                    catch(FormatException){
                        Log.error("Please enter a valid number for quantity");
                        continue;
                    }
                    recipeItems.Add(itemName, quantity);
                    break;
                }
            }
            return recipeItems;
        }

        // Updations
        public static void updateRecipe(){
            string recipeName = Util.validateStringInput("Please enter recipe name : ");

            if(!Recipe.checkContainsRecipe(recipeName)){
                Log.error("No recipe exist with that name");
                return;
            }

            System.Console.WriteLine("Enter the updated recipe items : ");

            Dictionary<string, int> recipeItems = takeRecipeInput();

            if(!Recipe.updateRecipe(recipeName, recipeItems)){
                Log.error("Failed to update the recipe");
                return;
            }

            Log.success("Successfully updated the recipe");
            
        }

        public static void deleteRecipe(){
            string recipeName = Util.validateStringInput("Please enter recipe name : ");
        
            if(!Recipe.deleteRecipe(recipeName)){
                Log.error("This recipe doesn't exist");
                return;
            }
            Log.success("Successfully deleted the recipe");
        }

        public static void useRecipe(){
            string recipeName = Util.validateStringInput("Please enter recipe name : ");
            int servings = Util.validateIntInput("Please enter the number of servings");

            if(!Recipe.checkContainsRecipe(recipeName)){
                Log.error("This recipe doesn't exist");
                return;
            }

            Tuple<bool, Dictionary<string, int>, Dictionary<string, int>> result =  Recipe.useRecipe(recipeName, servings);

            if(result.Item1 == false){
                Log.error("Couldn't use the recipe");
                if(result.Item2.Count > 0){
                    Log.error("Here are the out of stock items of recipe");
                    Util.printTable(result.Item2);
                }
                if(result.Item3.Count > 0){
                    Log.error("Here are the insufficient items of recipe in stock");
                    Util.printTable(result.Item3);
                }
                return;
            }
            
            Log.success("Successfully used the recipe");
        }

        public static void createRecipe(){
            string recipeName = Util.validateStringInput("Please enter recipe name : ");
            
            Dictionary<string, int> recipeItems = takeRecipeInput();
            if(recipeItems.Count < 1){
                Log.error("Couldn't add the recipe because items list is empty");
                return;
            }

            Recipe.createRecipe(recipeName, recipeItems);

            Log.success("\nSuccessfully added the recipe");
            
        }

        // Getters
        public static void showAllRecipes(){
            var recipes = Recipe.getAllRecipes();

            if(recipes.Count < 1){
                System.Console.WriteLine("No recipes");
                return;
            }

            RecipeActions.showRecipes(recipes);
        }

        public static void showRecipe(){
            string recipeName = Util.validateStringInput("Please enter recipe name : ");
            
            var recipe = Recipe.getRecipe(recipeName);
            if(recipe.Key == false){
                Log.error("No recipe found with that name");
                return;
            }
            System.Console.WriteLine($"{recipeName} : ");
            Util.printTable(recipe.Value);
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