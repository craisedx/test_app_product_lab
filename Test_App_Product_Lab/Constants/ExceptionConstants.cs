using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_App_Product_Lab.Constants
{
    public static class ExceptionConstants
    {
        public const string FileReadingNotFound = "File not found for reading";
        public const string RequestUnsuccessful = "The request was unsuccessful";
        public static string ProductNotFound(string searchParameterName) => $"Products by \"{searchParameterName}\" not found";
    }
}
