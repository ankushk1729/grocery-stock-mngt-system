// See https://aka.ms/new-console-template for more information

namespace GSMS {
    class Init {

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var data = Json.readFromJson();
            data.stock.Add("carrot", 10);
            Json.writeToJson(data);
        }
    }
}
