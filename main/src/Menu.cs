namespace GSMS
{
    class Menu
    {
        private RecipeActions? _recipeActions;
        private StockActions? _stockActions;

        public Menu(){
            _recipeActions = new RecipeActions();
            _stockActions = new StockActions();
        }
        
        public void showMenu(){
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("Grocery Stock Management System");
            Console.ForegroundColor = ConsoleColor.White;

            while(true){
                System.Console.WriteLine("Select 1 to show all items in stock");
                System.Console.WriteLine("Select 2 to show quantity of an item");
                System.Console.WriteLine("Select 3 to show items where quantity");
                System.Console.WriteLine("Select 4 to add item to stock");
                System.Console.WriteLine("Select 5 to delete item from stock");
                System.Console.WriteLine("Select 6 to increase quantity of an item");
                System.Console.WriteLine("Select 7 to decrease quantity of an item");
                System.Console.WriteLine("Select 8 to update quantity of an item");
                System.Console.WriteLine("Select 9 to show all recipes");
                System.Console.WriteLine("Select 10 to recipes which contains specific item");
                System.Console.WriteLine("Select 11 to show a recipe");
                System.Console.WriteLine("Select 12 to create a recipe");
                System.Console.WriteLine("Select 13 to delete a recipe");
                System.Console.WriteLine("Select 14 to use a recipe");
                System.Console.WriteLine("Select 15 to update a recipe");
                System.Console.WriteLine("Select 0 to exit");
                var input =  Util.validateIntInput("Enter your choice : ", 0);
                
                switch(input){
                    case 1:
                        _stockActions!.showQuantities();
                        break;
                    case 2:
                        _stockActions!.showQuantityOfAnItem();
                        break;
                    case 3:
                        _stockActions!.showItemsWhereQuantity();
                        break;
                    case 4:
                        _stockActions!.addItem();
                        break;    
                    case 5:
                        _stockActions!.deleteItem();
                        break;
                    case 6:
                        _stockActions!.increaseQuantityOfItem();
                        break;
                    case 7:
                        _stockActions!.decreaseQuantityOfItem();
                        break;
                    case 8:
                        _stockActions!.updateQuantityOfItem();
                        break;
                    case 9:
                        _recipeActions!.showAllRecipes();
                        break;
                    case 10:
                        _recipeActions!.showRecipesThatContainsItem();
                        break;
                    case 11:
                        _recipeActions!.showRecipe();
                        break;
                    case 12:
                        _recipeActions!.createRecipe();
                        break;
                    case 13:
                        _recipeActions!.deleteRecipe();
                        break;
                    case 14:
                        _recipeActions!.useRecipe();
                        break;
                    case 15:
                        _recipeActions!.updateRecipe();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }

            }
        }
    }
}