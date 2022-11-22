using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test_App_Product_Lab.BusinessLogic.Interfaces;
using Test_App_Product_Lab.Constants;
using Test_App_Product_Lab.Models;

namespace Test_App_Product_Lab.BusinessLogic.Services.ExcelWork
{
    public class WbExcelWork : IExcelWork
    {
        private readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\"  + ExcelConstants.NameWbExcelFile;
        
        public WbExcelWork()
        {

        }

        /// <summary>
        /// Implements <see cref="IExcelWork.SaveToExcelBySearchParameterName(AllProductData, string)"/>
        /// <para>Saving all products in Excel.</para>
        /// </summary>
        /// <param name="allProducts">All products.</param>
        /// <param name="searchParameterName">The parameter by which the search will be performed.</param>
        /// <returns></returns>
        public async Task SaveToExcelBySearchParameterName(AllProductData allProducts, string searchParameterName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(Path)))
            {
                var item = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == searchParameterName);
                if (item == null)
                {
                    package.Workbook.Worksheets.Add(searchParameterName);
                }
                else
                {
                    item.Select(); 
                }
                var headerRow = new List<string[]>()
                    {
                        new [] { ExcelConstants.TitleColNameExcel, ExcelConstants.BrandColNameExcel, ExcelConstants.IdColNameExcel, ExcelConstants.FeedbacksColNameExcel, ExcelConstants.PriceColNameExcel }
                    };

                var lastRange = char.ConvertFromUtf32(headerRow[0].Length + 64);
                var headerRange = "A1:" + lastRange + "1";

                var worksheet = package.Workbook.Worksheets[searchParameterName];

                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                var countProducts = allProducts.AppProduct.ProductInfos.Count;
                var numberString = 2;

                for (var i = 0; i < countProducts; i++)
                {
                    var rangeItems = $"A{numberString}:" + lastRange + $"{numberString++}";
                    var dataRow = new List<string[]>()
                        {
                            new string[] {
                                allProducts.AppProduct.ProductInfos[i].Name,
                                allProducts.AppProduct.ProductInfos[i].Brand,
                                allProducts.AppProduct.ProductInfos[i].Id.ToString(),
                                allProducts.AppProduct.ProductInfos[i].FeedBacks.ToString(),
                                (allProducts.AppProduct.ProductInfos[i].Price / 100).ToString()
                            }
                        };

                    worksheet.Cells[rangeItems].LoadFromArrays(dataRow);
                }
                
                await package.SaveAsAsync(Path);
            }
        }
    }
}
