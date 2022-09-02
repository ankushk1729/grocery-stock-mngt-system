// See https://aka.ms/new-console-template for more information

namespace GSMS {
    class Init {

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var data = Json.readFromJson();
            data.stock.Add("guava", 5);
            Json.writeToJson(data);
        }
    }
}
