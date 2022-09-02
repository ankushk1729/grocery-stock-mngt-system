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
    }
}