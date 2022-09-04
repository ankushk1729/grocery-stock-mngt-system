namespace GSMS
{
    class StockActions
    {
        // Updations

        public static void increaseQuantityOfItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity which should be added : ");
            

            if(!Stock.increaseQuantityOfItem(itemName, quantity)){
                Log.error("This item doesn't exist in stock, try adding it first");
                return;
            }

            Log.success("Successfully updated the stock");
        }
        
        public static void decreaseQuantityOfItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity which should be subtracted : ");

            if(!Stock.decreaseQuantityOfItem(itemName, quantity)){
                Log.error("This item doesn't exist in stock, try adding it first");
                return;
            }

            Log.success("Successfully updated the stock");
        }

        public static void addItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity : ");

            if(!Stock.addItem(itemName, quantity)){
                Log.error("This item already exist in stock");
                return;
            }

            Log.success("Successfully added item to stock");
        }


        public static void deleteItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");

            if(!Stock.deleteItem(itemName)){
                Log.error("This item doesn't exist in stock");
                return;
            }

            Log.success("Successfully deleted item from stock");
        }

         public static void updateQuantityOfItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity : ");

            Stock.updateQuantityOfItem(itemName, quantity);
            Log.success("Successfully updated item to stock");
        }

        // Loggers
        public static void showQuantityOfAnItem(){

            string itemName = Util.validateStringInput("Please enter the item name : ");
            
            int quantity = Stock.getQuantityOfAnItem(itemName);

            if(quantity == -1) {
                Log.error("No such item in stock");
                return;
            }

            Util.printTable(new Dictionary<string, int>(){{itemName, quantity}});
        }

        public static void showQuantities(){
            var stock = Stock.getQuantities();

            if(stock.Count < 1){
                System.Console.WriteLine("Stock is currently empty");
                return;
            }

            Util.printTable(stock);
        }

        public static void showItemsWhereQuantityIsGreaterThan(int quantity){
            var filteredItems = Stock.findItemsWhereQuantityIsGreaterThan(quantity);
            System.Console.WriteLine($"Items which have quantity greater than : {quantity}");
            Util.printTable(filteredItems);
        }

        public static void showItemsWhereQuantityIsLessThan(int quantity){
            var filteredItems = Stock.findItemsWhereQuantityIsLessThan(quantity);
            System.Console.WriteLine($"Items which have quantity less than : {quantity}");
            Util.printTable(filteredItems);
        }

        public static void showItemsWhereQuantityIsEqualTo(int quantity){
            var filteredItems = Stock.findItemsWhereQuantityIsEqualTo(quantity);
            System.Console.WriteLine($"Items which have quantity is equal to : {quantity}");
            Util.printTable(filteredItems);
        }
    }
}