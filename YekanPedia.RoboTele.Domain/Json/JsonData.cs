﻿namespace YekanPedia.RoboTele.Domain.Json {     using System;     using System.Collections;     using System.Collections.Generic;     using System.Web.Script.Serialization;      public class JsonData     {         readonly Dictionary<string, object> _dictionary;          public JsonData(Dictionary<string, object> dictionary)         {             _dictionary = dictionary;         }          public T Get<T>(string name)         {             if (_dictionary.ContainsKey(name))             {                 return (T)_dictionary[name];             }              return default(T);         }          public JsonData GetJson(string name)         {             return _dictionary.ContainsKey(name) ?                 new JsonData((Dictionary<string, object>)_dictionary[name]) : null;         }          public IEnumerable<JsonData> GetJsonList(string name)         {             if (!_dictionary.ContainsKey(name))             {                 yield break;             }              var arrayList = (ArrayList)_dictionary[name];             foreach (var item in arrayList)             {                 yield return new JsonData((Dictionary<string, object>)item);             }         }          public DateTime? GetDateTime(string name)         {             return _dictionary.ContainsKey(name) ?                 ((int?)_dictionary[name]).ToDateTime() : null;         }          public bool Has(string name)         {             return _dictionary.ContainsKey(name);         }          public int Count => _dictionary.Count;          public static string Serialize(object input)         {             var javaScriptSerializer = new JavaScriptSerializer();             return javaScriptSerializer.Serialize(input);         }          public static JsonData Deserialize(string input)         {             var javaScriptSerializer = new JavaScriptSerializer();             return new JsonData(javaScriptSerializer.Deserialize<Dictionary<string, object>>(input));         }     } } 