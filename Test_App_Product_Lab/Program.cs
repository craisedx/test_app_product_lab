﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using OfficeOpenXml;
using Test_App_Product_Lab.BusinessLogic.Services;
using Test_App_Product_Lab.BusinessLogic.Services.Marketplaces.Wildberries;
using Test_App_Product_Lab.Proxy;
using Test_App_Product_Lab.BusinessLogic.Services.FileWork;
using Test_App_Product_Lab.BusinessLogic.Interfaces;
using Test_App_Product_Lab.Constants;
using Test_App_Product_Lab.Models;

namespace Test_App_Product_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(MailAsync).GetAwaiter().GetResult();
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }

        private static async Task MailAsync()
        {
            try
            {
                var wildberries = new MarketplaceContext(new Wildberries());

                //add the path to your file for reading.
                IFileWork fileRead = new FileWork(@"C:/text.txt");

                var fileNamesToSearch = await fileRead.GetNamesToSearch();

                foreach(var item in fileNamesToSearch)
                {
                    Console.WriteLine("Parse search name - " + item);
                    await wildberries.ParseProductListToExcelBySearchParameterName(item);
                }
                Console.WriteLine("Done!");
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine(fileNotFoundException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}