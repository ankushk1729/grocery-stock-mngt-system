using Newtonsoft.Json;
using System;

namespace GSMS {
    public class Json {
        public static JsonData readFromJson(){
            var jsonData = File.ReadAllText(@"F:\Project\GSMS\stock.json");

            var resultData = JsonConvert.DeserializeObject<JsonData>(jsonData);
            return resultData!;

        }

        public static void writeToJson(JsonData data){
            var serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(@"F:\Project\GSMS\stock.json", serializedData);
        }
    }
}