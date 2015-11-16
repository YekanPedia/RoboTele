﻿ namespace YekanPedia.RoboTele.Proxy
{
    using System.Configuration;
    public static class AppSettings {
        public static bool ClientValidationEnabled => bool.Parse(ConfigurationManager.AppSettings["ClientValidationEnabled"]);
        public static bool UnobtrusiveJavaScriptEnabled => bool.Parse(ConfigurationManager.AppSettings["UnobtrusiveJavaScriptEnabled"]);
        public static string UserName => ConfigurationManager.AppSettings["UserName"];
        public static string Password => ConfigurationManager.AppSettings["Password"];
        public static string BotUserName => ConfigurationManager.AppSettings["BotUserName"];
        public static string ApiKey => ConfigurationManager.AppSettings["ApiKey"];
    }
}