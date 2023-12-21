using The_IT_Depot_Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Tests.PageObjects;
using Serilog;

namespace The_IT_Depot_Tests.TestScripts
{
    [TestFixture]
    internal class SearchProductAndBuyTest : Corecodes
    {
        [Test,Order(1)]
        [TestCase("price_desc")]
        [Author("Vishnu T","vishnu.thulaseedharanpillai@ust.com")]
        [Category("End to End Test Scenario One")]
        public void SearchAndBuyProductTest(string choose)
        {
            LogFunction();
            ITDepot_HomePage homePage = new(driver);
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/ITDepotInputData.xlsx";

            string? sheetName = "ITDepotInput";
            List<ITDepotData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {
                if(!driver.Url.Equals("https://www.theitdepot.com/"))
                {
                    driver.Navigate().GoToUrl("https://www.theitdepot.com/");
                }
                homePage.InputSearchBox(excelData.SearchItem);
                var viewproductPage = homePage.ViewProduct();  
                Thread.Sleep(3000);
                viewproductPage.SortByClick();
                Thread.Sleep(3000);
                viewproductPage.ChooseItemClick(choose);
                Thread.Sleep(3000);
                viewproductPage.CategoryClick();
                Thread.Sleep(3000);
                var buyNowPage = viewproductPage.ClickBuyNow(excelData.ProductNo);
                Thread.Sleep(3000);
                var shopingCartPage = buyNowPage.BuyNowClick();
                Thread.Sleep(3000);
                shopingCartPage.QuantityChange(excelData.Qty);
                Thread.Sleep(3000);
                var checkoutPage = shopingCartPage.CheckoUtClick();
                Thread.Sleep(2000);
                checkoutPage.TypeInputUser(excelData.Name);
                checkoutPage.TypeInputEmail(excelData.Email);
                checkoutPage.TypeInputMobile(excelData.Mobile);
                checkoutPage.TypeInputPassword(excelData.Password);
                checkoutPage.TypeConfirmPassword(excelData.Password);
                checkoutPage.SignUpButtonClickz();
                Thread.Sleep(3000);
                ScreenShots.TakeScreenShot(driver);
                try
                {
                    Assert.That(driver.Url.Contains("checkout"));
                    Log.Information("Search And Buy Product Test Pass!!!");
                    test = extent.CreateTest("Search And Buy Product Scenario");
                    test.Pass("Search And Buy Product Test-Pass");
                }
                catch (AssertionException)
                {
                    ScreenShots.TakeScreenShot(driver);
                    Log.Error("Search And Buy Product Test Fail!!!");
                    test = extent.CreateTest("Search And Buy Product Scenario");
                    test.Fail("Search And Buy Product Test-Fail");
                }
                
                
               
                   
            }


        }
    }
}
