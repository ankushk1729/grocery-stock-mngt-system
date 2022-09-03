using System;
namespace GSMS {
    class Stock {

        // Updations
        public static void increaseQauntityOfItem(string itemName, int count = 1){
            var data = Json.readFromJson();
            data.stock[itemName] = data.stock[itemName] + count;
            Json.writeToJson(data);
        }

        public static void decreaseQuantityOfItem(string itemName, int count = 1){
            var data = Json.readFromJson();
            data.stock[itemName] = data.stock[itemName] - count;
            Json.writeToJson(data);
        }

        public static void updateQuantityOfItem(string itemName, int quantity){
            var data = Json.readFromJson();
            data.stock[itemName] = quantity;
            Json.writeToJson(data);
        }

        public static void addItem(string itemName, int quantity = 1){
            if(Stock.checkContainsItem(itemName)){
                return;
            }
            var data = Json.readFromJson();
            data.stock[itemName] = quantity;
            Json.writeToJson(data);
        }

        public static void deleteItem(string itemName){
            if(!Stock.checkContainsItem(itemName)){
                return;
            }
            var data = Json.readFromJson();
            data.stock.Remove(itemName);
            Json.writeToJson(data);
        }

        // Getters
        public static int getQuantityOfAnItem(string itemName){
            var data = Json.readFromJson();
            return data.stock[itemName];
        }

        public static Dictionary<string, int> getQuantities(){
            var data = Json.readFromJson();
            return data.stock;
        }

        public static bool checkContainsItem(string itemName){
            var data = Json.readFromJson();
            return data.stock.ContainsKey(itemName);
        }

        public static Dictionary<string, int> findItemsWhereQuantityIsGreaterThan(int quantity){
            var data = Json.readFromJson();

            Dictionary<string, int> filteredItems = data.stock.Where(item => item.Value > quantity).ToDictionary(item => item.Key, item => item.Value);
            return filteredItems;
        }

        public static Dictionary<string, int> findItemsWhereQuantityIsLessThan(int quantity){
            var data = Json.readFromJson();

            Dictionary<string, int> filteredItems = data.stock.Where(item => item.Value < quantity).ToDictionary(item => item.Key, item => item.Value);
            return filteredItems;
        }

        public static Dictionary<string, int> findItemsWhereQuantityIsEqualTo(int quantity){
            var data = Json.readFromJson();

            Dictionary<string, int> filteredItems = data.stock.Where(item => item.Value == quantity).ToDictionary(item => item.Key, item => item.Value);
            return filteredItems;
        }

        // Loggers
        public static void printQuantityOfAnItem(string itemName){
            int quantity = Stock.getQuantityOfAnItem(itemName);

            Util.printTable(new Dictionary<string, int>(){{itemName, quantity}});
        }

        public static void printQuantities(){
            var stock = Stock.getQuantities();

            Util.printTable(stock);
        }

        public static void printItemsWhereQuantityIsGreaterThan(int quantity){
            var filteredItems = Stock.findItemsWhereQuantityIsGreaterThan(quantity);
            System.Console.WriteLine($"Items which have quantity greater than : {quantity}");
            Util.printTable(filteredItems);
        }

        public static void printItemsWhereQuantityIsLessThan(int quantity){
            var filteredItems = Stock.findItemsWhereQuantityIsLessThan(quantity);
            System.Console.WriteLine($"Items which have quantity less than : {quantity}");
            Util.printTable(filteredItems);
        }

        public static void printItemsWhereQuantityIsEqualTo(int quantity){
            var filteredItems = Stock.findItemsWhereQuantityIsEqualTo(quantity);
            System.Console.WriteLine($"Items which have quantity is equal to : {quantity}");
            Util.printTable(filteredItems);
        }
    }
}