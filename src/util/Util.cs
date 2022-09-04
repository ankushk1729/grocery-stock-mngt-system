using System;
using BetterConsoleTables;
namespace GSMS {
    class Util {
        public static void printTable(Dictionary<string, int> data){
            var table = new Table("Item", "Quantity");
             table.Config = TableConfiguration.UnicodeAlt();


            foreach(KeyValuePair<string, int> kv in data){
                table.AddRow(kv.Key, kv.Value);
            }
            Console.Write(table.ToString());
        }

        public static int validateIntInput(string message = "Please enter value", int minValue = 1){
            int quantity;
            while(true){
                try {
                    System.Console.WriteLine($"{message}");
                    quantity = int.Parse(Console.ReadLine()!);
                    if(quantity < minValue) throw new FormatException();
                }
                catch(FormatException){
                    Log.error("Please enter a valid number");
                    continue;
                }
                break;
            }
            return quantity;
        }

        public static string validateStringInput(string message = "Please enter value"){
            string itemName;
            while(true){
                try {
                    System.Console.WriteLine($"{message}");
                    itemName = Console.ReadLine()!;
                    if(itemName == "") throw new FormatException();
                }
                catch(FormatException){
                    Log.error("Please enter valid name");
                    continue;
                }
                break;
            }
            return itemName!;
        }
    }
}