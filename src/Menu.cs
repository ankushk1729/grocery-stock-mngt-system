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
                System.Console.WriteLine("Select 3 to add item to stock");
                System.Console.WriteLine("Select 4 to delete item from stock");
                System.Console.WriteLine("Select 5 to increase quantity of an item");
                System.Console.WriteLine("Select 6 to decrease quantity of an item");
                System.Console.WriteLine("Select 7 to update quantity of an item");
                System.Console.WriteLine("Select 8 to show all recipes");
                System.Console.WriteLine("Select 9 to show a recipe");
                System.Console.WriteLine("Select 10 to create a recipe");
                System.Console.WriteLine("Select 11 to delete a recipe");
                System.Console.WriteLine("Select 12 to use a recipe");
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
                        StockActions.addItem();
                        break;    
                    case 4:
                        StockActions.deleteItem();
                        break;
                    case 5:
                        StockActions.increaseQuantityOfItem();
                        break;

                    case 6:
                        StockActions.decreaseQuantityOfItem();
                        break;
                    case 7:
                        StockActions.updateQuantityOfItem();
                        break;
                    case 8:
                        RecipeActions.showAllRecipes();
                        break;
                    case 9:
                        RecipeActions.showRecipe();
                        break;
                    case 10:
                        RecipeActions.createRecipe();
                        break;
                    case 11:
                        RecipeActions.deleteRecipe();
                        break;
                    case 12:
                        RecipeActions.useRecipe();
                        break;
                    case 0:
                        return;
                }

            }
        }
    }
}