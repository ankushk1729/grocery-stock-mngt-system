namespace GSMS
{
    class Menu
    {
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
                        StockActions.showQuantities();
                        break;
                    case 2:
                        StockActions.showQuantityOfAnItem();
                        break;
                    case 3:
                        StockActions.showItemsWhereQuantity();
                        break;
                    case 4:
                        StockActions.addItem();
                        break;    
                    case 5:
                        StockActions.deleteItem();
                        break;
                    case 6:
                        StockActions.increaseQuantityOfItem();
                        break;
                    case 7:
                        StockActions.decreaseQuantityOfItem();
                        break;
                    case 8:
                        StockActions.updateQuantityOfItem();
                        break;
                    case 9:
                        RecipeActions.showAllRecipes();
                        break;
                    case 10:
                        RecipeActions.showRecipesThatContainsItem();
                        break;
                    case 11:
                        RecipeActions.showRecipe();
                        break;
                    case 12:
                        RecipeActions.createRecipe();
                        break;
                    case 13:
                        RecipeActions.deleteRecipe();
                        break;
                    case 14:
                        RecipeActions.useRecipe();
                        break;
                    case 15:
                        RecipeActions.updateRecipe();
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