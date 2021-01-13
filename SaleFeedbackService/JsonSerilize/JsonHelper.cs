using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SaleFeedbackService.JsonSerilize
{
    public class JsonHelper
    {
        #region test
        //    var appOption = new AppOption { IsEnableJsonSerilize = false, AppName = "TestJson", LoggerPath = AppDomain.CurrentDomain.BaseDirectory };
        //    var udpSocketOption = new UdpSocketOption { IsEnableUdp = true, IsLoggerUdp = false, Port = 4322 };
        //    var tcpSocketOption = new TcpSocketOption { IP = "192.168.31.188", Port = 7777, IsEnableTcp = true, IsLoggerTcp = true };
        //    var testoption = new { AppName = appOption, tcpSocketOption = tcpSocketOption, udpSocketOption = udpSocketOption };

        //    JsonBuilder test = JsonHelper.WriteTToJsonBulider(testoption);
        //    Console.WriteLine(test.ToJson());
        //        var arraydata = new List<string>();
        //        for (int i = 0; i< 5; i++)
        //        {

        //            arraydata.Add(i.ToString());//str是i转string
        //        }

        //JsonBuilder json = JsonHelper.CreateJsonObjectBuilder();
        //JsonBuilder array = JsonHelper.CreateJsonArrayBuilder();
        //array.AddItem(new JsonBuilder().SetProperty("item1", "item1__value"));
        //        array.AddItem(new JsonBuilder().SetProperty("item2", "item2__value"));
        //        json = json.SetProperty("name", "Zack").SetProperty("blog", "cnblogs").SetProperty("obj", (new JsonBuilder().SetProperty("value", 1000))).SetProperty("array", array).SetProperty("ProjectIds", arraydata);
        //Console.WriteLine(json.ToJson());
        #endregion
        public static JsonBuilder CreateJsonObjectBuilder()
        {
            JsonBuilder builder = new JsonBuilder();
            return builder;
        }
        public static JsonBuilder CreateJsonArrayBuilder()
        {
            JsonBuilder builder = new JsonBuilder();
            return builder.ToArray();
        }
        public static string GetSerilization(object obj)
        {
            if (obj is null) return null;
            String strJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return strJson;
        }
        public static T GetDeSerilization<T>(string obj)
        {
            if (obj is null) throw new Exception("Json string is null");
            T res = JsonConvert.DeserializeObject<T>(obj);
            return res;
        }
        public static void WriteToFile(String path, String json)
        {
            File.WriteAllText(path, json);
        }
        public static String ReadFromFile(String path)
        {
            return File.ReadAllText(path);
        }
        public static T GetT<T>(string path, string key = null)
        {
            try
            {
                StreamReader file = File.OpenText(path);
                JsonTextReader reader = new JsonTextReader(file);
                JToken jsonToken = JToken.ReadFrom(reader);
                T obj = default;
                if (key == null)
                {
                    obj = jsonToken.ToObject<T>();
                }
                else
                {
                    obj = jsonToken[key].ToObject<T>();
                }

                file.Close();
                return obj;
            }
            catch { }
            return default;
        }
        public static JsonBuilder WriteTToJsonBulider<T>(T value)
        {
            try
            {
                if (value == null) return default;
                var jsonBuilder = new JsonBuilder();
                var type = value.GetType();
                if (type.IsTypeDefinition)//数组、引用、指针或实例化泛型类型不是
                {
                    jsonBuilder.SetProperty(type.Name, value);
                    return jsonBuilder;
                }
                var props = type.GetProperties();

                foreach (var item in props)
                {
                    jsonBuilder.SetProperty(item.Name, item.GetValue(value));
                }

                return jsonBuilder;
            }
            catch (Exception) { }
            return default;
        }
    }
    public class JsonBuilder
    {
        private JsonBuilder jsonBuilder;
        private Dictionary<string, object> JsonObject;
        private List<Dictionary<string, object>> JsonArray;

        public JsonBuilder()
        {
            jsonBuilder = this;
            JsonObject = new Dictionary<string, object>();
        }
        public JsonBuilder ToObject()
        {
            if (JsonArray != null && JsonArray.Count > 0)
            {
                JsonObject = JsonArray[0];
            }
            else
            {
                JsonArray = null;
                JsonObject = new Dictionary<string, object>();
            }
            return jsonBuilder;
        }
        public JsonBuilder ToArray()
        {
            JsonArray = new List<Dictionary<string, object>>();
            if (JsonObject.Count > 0)
                JsonArray.Add(JsonObject);
            return jsonBuilder;
        }
        public bool IsArray()
        {
            return JsonArray != null;
        }
        public JsonBuilder SetProperty(string key, object value)
        {
            if (IsArray())
                return jsonBuilder;
            if (typeof(JsonBuilder) == value.GetType())
            {
                JsonBuilder JsonValue = value as JsonBuilder;
                if (JsonValue.IsArray())
                    value = JsonValue.JsonArray;
                else
                    value = JsonValue.JsonObject;
            }
            if (JsonObject.ContainsKey(key))
            {
                JsonObject[key] = value;
            }
            else
            {
                JsonObject.Add(key, value);
            }

            return jsonBuilder;

        }
        public JsonBuilder RemoveProperty(string key)
        {
            if (IsArray())
                return jsonBuilder;
            if (JsonObject.ContainsKey(key))
            {
                JsonObject.Remove(key);
            }
            return jsonBuilder;
        }
        public JsonBuilder AddItem(JsonBuilder jsonBuilder)
        {
            if (!IsArray())
                return jsonBuilder;
            if (jsonBuilder.IsArray())
                JsonArray.AddRange(jsonBuilder.JsonArray);
            else
                JsonArray.Add(jsonBuilder.JsonObject);
            return jsonBuilder;
        }
        public JsonBuilder RemoveItem(JsonBuilder jsonBuilder)
        {
            if (!IsArray())
                return this.jsonBuilder;
            if (jsonBuilder.IsArray())
            {
                foreach (var deleItem in jsonBuilder.JsonArray)
                {
                    if (JsonArray.Contains(deleItem))
                        JsonArray.Remove(deleItem);
                }
            }
            else
            {
                if (JsonArray.Contains(jsonBuilder.JsonObject))
                    JsonArray.Remove(jsonBuilder.JsonObject);
            }
            return this.jsonBuilder;
        }
        public string ToJson()
        {
            object ToSerialize;
            if (IsArray())
                ToSerialize = jsonBuilder.JsonArray;
            else
                ToSerialize = jsonBuilder.JsonObject;
            return JsonHelper.GetSerilization(ToSerialize);
        }
    }
}
