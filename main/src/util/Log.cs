namespace GSMS
{
    class Log
    {
        public static void success(string message){
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void error(string message){
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}