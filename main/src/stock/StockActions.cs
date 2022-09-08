namespace GSMS
{
    class StockActions
    {
        private Stock _stock;
        public StockActions(){
            _stock = new Stock(new Json());
        }

        // Updations

        public void increaseQuantityOfItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity which should be added : ");
            

            if(!_stock.increaseQuantityOfItem(itemName, quantity)){
                Log.error("This item doesn't exist in stock, try adding it first");
                return;
            }

            Log.success("Successfully updated the stock");
        }
        
        public void decreaseQuantityOfItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity which should be subtracted : ");

            if(!_stock.decreaseQuantityOfItem(itemName, quantity)){
                Log.error("This item doesn't exist in stock, try adding it first");
                return;
            }

            Log.success("Successfully updated the stock");
        }

        public void addItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity : ");

            if(!_stock.addItem(itemName, quantity)){
                Log.error("This item already exist in stock");
                return;
            }

            Log.success("Successfully added item to stock");
        }


        public void deleteItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");

            if(!_stock.deleteItem(itemName)){
                Log.error("This item doesn't exist in stock");
                return;
            }

            Log.success("Successfully deleted item from stock");
        }

         public void updateQuantityOfItem(){
            string itemName = Util.validateStringInput("Please enter item name : ");
            int quantity = Util.validateIntInput("Please enter the quantity : ");

            _stock.updateQuantityOfItem(itemName, quantity);
            Log.success("Successfully updated item to stock");
        }

        // Loggers
        public void showQuantityOfAnItem(){

            string itemName = Util.validateStringInput("Please enter the item name : ");
            
            int quantity = _stock.getQuantityOfAnItem(itemName);

            if(quantity == -1) {
                Log.error("No such item in stock");
                return;
            }

            Util.printTable(new Dictionary<string, int>(){{itemName, quantity}});
        }

        public void showQuantities(){
            var stock = _stock.getQuantities();

            if(stock.Count < 1){
                System.Console.WriteLine("Stock is currently empty");
                return;
            }

            Util.printTable(stock);
        }

        public void showItemsWhereQuantityIsGreaterThan(){
            int quantity = Util.validateIntInput("Enter the quantity :");
            var filteredItems = _stock.findItemsWhereQuantityIsGreaterThan(quantity);
            System.Console.WriteLine($"Items which have quantity greater than : {quantity}");
            Util.printTable(filteredItems);
        }

        public void showItemsWhereQuantityIsLessThan(){
            int quantity = Util.validateIntInput("Enter the quantity :");
            var filteredItems = _stock.findItemsWhereQuantityIsLessThan(quantity);
            System.Console.WriteLine($"Items which have quantity less than : {quantity}");
            Util.printTable(filteredItems);
        }

        public void showItemsWhereQuantityIsEqualTo(){
            int quantity = Util.validateIntInput("Enter the quantity :");
            var filteredItems = _stock.findItemsWhereQuantityIsEqualTo(quantity);
            System.Console.WriteLine($"Items which have quantity is equal to : {quantity}");
            Util.printTable(filteredItems);
        }

         public void showItemsWhereQuantity(){
            while(true){
                System.Console.WriteLine("Select 1 to find items where quantity is greater than");
                System.Console.WriteLine("Select 2 to find items where quantity is lesser than");
                System.Console.WriteLine("Select 3 to find items where quantity is equal to");
                System.Console.WriteLine("Select 0 to exit");
                int choice = Util.validateIntInput("Enter your choice : ", 0);

                switch(choice) {
                    case 1 :
                        showItemsWhereQuantityIsGreaterThan();
                        break;
                    case 2:
                        showItemsWhereQuantityIsLessThan();
                        break;
                    case 3:
                        showItemsWhereQuantityIsEqualTo();
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