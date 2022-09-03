namespace GSMS
{
    class StockActions
    {
        public static void showQuantityOfAnItem(string itemName){
            int quantity = Stock.getQuantityOfAnItem(itemName);

            Util.printTable(new Dictionary<string, int>(){{itemName, quantity}});
        }

        public static void showQuantities(){
            var stock = Stock.getQuantities();

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