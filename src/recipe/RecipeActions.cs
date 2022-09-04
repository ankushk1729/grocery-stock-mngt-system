namespace GSMS 
{
    class RecipeActions
    {
        public static void deleteRecipe(){
            string recipeName;
            while(true){
                try {
                    Console.WriteLine("Enter the name of recipe : ");
                    recipeName = Console.ReadLine();
                    if(recipeName == "") throw new FormatException();
                }
                catch(FormatException e){
                    Log.error("Please enter a valid recipe name");
                    continue;
                }
                break;
            }
            if(!Recipe.deleteRecipe(recipeName)){
                Log.error("This recipe doesn't exist");
                return;
            }
            Log.success("Successfully deleted the recipe");
        }

        public static void useRecipe(){
            string recipeName;
            while(true){
                try {
                    Console.WriteLine("Enter the name of recipe : ");
                    recipeName = Console.ReadLine();
                    if(recipeName == "") throw new FormatException();
                }
                catch(FormatException e){
                    Log.error("Please enter a valid recipe name");
                    continue;
                }
                break;
            }
            if(!Recipe.checkContainsRecipe(recipeName)){
                Log.error("This recipe doesn't exist");
                return;
            }

            Tuple<bool, Dictionary<string, int>, Dictionary<string, int>> result =  Recipe.useRecipe(recipeName);

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
            string recipeName;
            Dictionary<string, int> recipeItems = new Dictionary<string, int>();
            while(true){
                try {
                    Console.WriteLine("Enter the name of recipe : ");
                    recipeName = Console.ReadLine();
                    if(recipeName == "") throw new FormatException();
                }
                catch(FormatException e){
                    Log.error("Please enter a valid recipe name");
                    continue;
                }
                break;
            }
            System.Console.WriteLine("Enter the recipe items\n");
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
                        itemName = Console.ReadLine();
                        if(itemName == "") throw new FormatException();
                    }
                    catch(FormatException e){
                        Log.error("Please enter alphabets only for item name");
                        continue;
                    }
                    try {
                        Console.WriteLine("Enter the quantity : ");
                        quantity = int.Parse(Console.ReadLine());
                        if(quantity <= 0) throw new FormatException();
                    }
                    catch(FormatException e){
                        Log.error("Please enter a valid number for quantity");
                        continue;
                    }
                    recipeItems.Add(itemName, quantity);
                    break;
                }
            }

            if(recipeItems.Count < 1){
                Log.error("Couldn't add the recipe because items list is empty");
                return;
            }

            Recipe.createRecipe(recipeName, recipeItems);

            Log.success("\nSuccessfully added the recipe");
            
        }

        public static void showAllRecipes(){
            var recipes = Recipe.getAllRecipes();

            if(recipes.Count < 1){
                System.Console.WriteLine("No recipes");
                return;
            }

            RecipeActions.showRecipes(recipes);
        }

        public static void showRecipe(){
            string recipeName;
            while(true){
                try {
                    Console.WriteLine("Enter the name of recipe : ");
                    recipeName = Console.ReadLine();
                    if(recipeName == "") throw new FormatException();
                }
                catch(FormatException e){
                    Log.error("Please enter a valid recipe name");
                    continue;
                }
                break;
            }
            var recipe = Recipe.getRecipe(recipeName);
            if(recipe == null){
                Log.error("No recipe found with that name");
                return;
            }
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