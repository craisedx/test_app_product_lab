using System;
using System.Collections.Generic;
namespace Test_App_Product_Lab.Constants
{
    public static class ProxyApiInfoConstants
    {
        public const string FirstHeaderKey = "X-RapidAPI-Key";
        public const string FirstHeaderValue = "247bde8d67mshbc66d48715ddadcp114906jsneb85b9fad9b9";
        public const string SecondHeaderKey = "X-RapidAPI-Host";
        public const string SecondHeaderValue = "ephemeral-proxies.p.rapidapi.com";
        public const string Url = "https://ephemeral-proxies.p.rapidapi.com/v2/datacenter/proxy?countries=RU%2CPL";

        public const string ProxyCheckGoogleUrl = "https://www.google.by/";
        public const string ProxyCheckYandexUrl = "https://yandex.by/";
        public const string ProxyCheckMozillaUrl = "https://www.mozilla.org/ru/";
        public const int CountTryToConnectProxy = 3;
    }
}
