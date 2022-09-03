using System;
namespace GSMS {
    class Stock {

        // Updations
        public static bool increaseQuantityOfItem(string itemName, int quantity = 1){
            if(!Stock.checkContainsItem(itemName)){
                return false;
            }
            var data = Json.readFromJson();
            data.stock[itemName] = data.stock[itemName] + quantity;
            Json.writeToJson(data);
            return true;
        }

        public static bool decreaseQuantityOfItem(string itemName, int quantity = 1){
            if(!Stock.checkContainsItem(itemName)){
                return false;
            }
            var data = Json.readFromJson();
            int updatedQuantity = data.stock[itemName] - quantity;
            if(updatedQuantity <= 0 ){
                data.stock.Remove(itemName);
            }
            else data.stock[itemName] = updatedQuantity;

            Json.writeToJson(data);
            return true;
        }

        public static void updateQuantityOfItem(string itemName, int quantity){
            if(!Stock.checkContainsItem(itemName)){
                Stock.addItem(itemName, quantity);
                return;
            }
            var data = Json.readFromJson();
            if(quantity <= 0 ){
                data.stock.Remove(itemName);
            }
            else data.stock[itemName] = quantity;
            Json.writeToJson(data);
        }

        public static bool addItem(string itemName, int quantity = 1){
            if(Stock.checkContainsItem(itemName)){
                return false;
            }
            var data = Json.readFromJson();
            if(quantity <= 0){
                return false;
            }
            data.stock[itemName] = quantity;
            Json.writeToJson(data);
            return true;
        }

        public static bool deleteItem(string itemName){
            if(!Stock.checkContainsItem(itemName)){
                return false;
            }
            var data = Json.readFromJson();
            data.stock.Remove(itemName);
            Json.writeToJson(data);
            return true;
        }

        // Getters
        public static int getQuantityOfAnItem(string itemName){
            if(!Stock.checkContainsItem(itemName)){
                return -1;
            }

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
    }
}