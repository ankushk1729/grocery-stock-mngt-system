using Newtonsoft.Json;
using System;

namespace GSMS {

    public interface IJson {
        JsonData readFromJson();
        void writeToJson(JsonData data);
    }
    public class Json : IJson
    {
        public JsonData readFromJson(){
            var jsonData = File.ReadAllText(@"F:\Project\GSMS\stock.json");

            var resultData = JsonConvert.DeserializeObject<JsonData>(jsonData);
            return resultData!;

        }
        public void writeToJson(JsonData data){
            var serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(@"F:\Project\GSMS\stock.json", serializedData);
        }
    }
}