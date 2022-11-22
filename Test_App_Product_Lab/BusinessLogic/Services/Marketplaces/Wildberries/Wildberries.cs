using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_App_Product_Lab.BusinessLogic.Interfaces;
using Test_App_Product_Lab.BusinessLogic.Services.ExcelWork;
using Test_App_Product_Lab.BusinessLogic.Services.HttpRequestWork;
using Test_App_Product_Lab.Constants;

namespace Test_App_Product_Lab.BusinessLogic.Services.Marketplaces.Wildberries
{
    public class Wildberries : IMarketplace
    {
        /// <summary>
        /// Implements <see cref="IMarketplace.ParseProductListToExcelBySearchParameterName(string)"/>
        /// <para>Getting products and saving them in excel.</para>
        /// </summary>
        /// <param name="searchParameterName">The parameter by which the search will be performed.</param>
        /// <returns></returns>
        public async Task ParseProductListToExcelBySearchParameterName(string searchParameterName)
        {
            var wbRequest = new WildberriesHttpRequestWork(new Proxy.ProxyManager());

            var products = await wbRequest.GetProductsWbByQueryAsync(searchParameterName);

            if (products == null)
            {
                Console.WriteLine(ExceptionConstants.ProductNotFound(searchParameterName));
                return;
            }

            IExcelWork wbExcel = new WbExcelWork();

            await wbExcel.SaveToExcelBySearchParameterName(products, searchParameterName);

        }
    }
}
