using Newtonsoft.Json;
using System;

namespace GSMS {
    class Json {
        public static JsonData readFromJson(){
            // var jsonData = new JsonData(){
            //     stock = new Dictionary<string, int>(){
            //         ["tomato"] =  1
            //     },
            //     recipes = new Dictionary<string, Dictionary<string, int>>(){
            //         ["pasta"] = new Dictionary<string, int>(){
            //             ["tomato"] = 1
            //         }
            //     }
            // };
            var jsonData = File.ReadAllText(@"stock.json");

            var resultData = JsonConvert.DeserializeObject<JsonData>(jsonData);
            return resultData;

        }

        public static void writeToJson(JsonData data){
            var serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(@"stock.json", serializedData);
        }
    }
}