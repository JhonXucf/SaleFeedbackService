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
        public static void WriteT<T>(string path, string key, T value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new Exception("key isn't allow null");
                }
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                string json = File.ReadAllText(path);               
                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                string sec = jsonObj is null ? null : jsonObj[key];
                dynamic secObj = sec != null ? JsonConvert.DeserializeObject(sec) : null;
                var output = string.Empty;
                if (secObj != null)
                {
                    var type = typeof(T);
                    PropertyInfo[] props = type.GetProperties();
                    foreach (var item in props)
                    {
                        //if (item.PropertyType.IsClass)以后再说递归实现
                        //{
                        //    string secItem = secObj[key];
                        //    dynamic secObjItem = secItem != null ? JsonConvert.DeserializeObject(secItem) : null;
                        //    if (secObjItem is null) continue;
                        //}
                        secObj[item.Name] = JToken.FromObject(item.GetValue(value));
                    }
                    jsonObj[key] = secObj;
                    output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                }
                else if (jsonObj != null && secObj == null)
                {
                    JObject jobject = JObject.Parse(json);
                    JObject newStu = new JObject(
               new JProperty("id", 2),
               new JProperty("name", "3班"),
               new JProperty("teacher", new JObject(
                                 new JProperty("yu", "qwe "),
                                 new JProperty("sx", "qwe"),
                                 new JProperty("yy", "qwe")
               )
                        )
               );
                    jobject["UdpSocketOption"]["Port"].Last.AddAfterSelf(JToken.FromObject(newStu));
                    output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                }
                else
                {
                    output = JsonConvert.SerializeObject(value, Formatting.Indented);
                }
                File.WriteAllText(path, output);
            }
            catch(Exception ex) { }
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
        public JsonBuilder SetProperty(string name, object value)
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
            //jsonBuilder = (IDictionary<string, object>)jsonBuilder;
            if (JsonObject.ContainsKey(name))
            {
                JsonObject[name] = value;
            }
            else
            {
                JsonObject.Add(name, value);
            }

            return jsonBuilder;

        }
        public JsonBuilder RemoveProperty(string name)
        {
            if (IsArray())
                return jsonBuilder;
            if (JsonObject.ContainsKey(name))
            {
                JsonObject.Remove(name);
            }
            return jsonBuilder;
        }
        public JsonBuilder AddItem(JsonBuilder jb)
        {
            if (!IsArray())
                return jsonBuilder;
            if (jb.IsArray())
                JsonArray.AddRange(jb.JsonArray);
            else
                JsonArray.Add(jb.JsonObject);
            return jsonBuilder;
        }
        public JsonBuilder RemoveItem(JsonBuilder jb)
        {
            if (!IsArray())
                return jsonBuilder;
            if (jb.IsArray())
            {
                foreach (var deleItem in jb.JsonArray)
                {
                    if (JsonArray.Contains(deleItem))
                        JsonArray.Remove(deleItem);
                }
            }
            else
            {
                if (JsonArray.Contains(jb.JsonObject))
                    JsonArray.Remove(jb.JsonObject);
            }
            return jsonBuilder;
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
