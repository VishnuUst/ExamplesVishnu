using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Tests.PageObjects;
using The_IT_Depot_Tests.Utilities;

namespace The_IT_Depot_Tests.TestScripts
{
    [TestFixture]
    internal class SearchAndAddToWishListTest : Corecodes
    {
        [Test]
        [Author("Vishnu T","vishnu.thulaseedharanpillai@ust.com")]
        [Category("End To End Test Scenario Two")]
        public void SearchAndAddToWishListTests()
        {
            LogFunction();
            test = extent.CreateTest("Search And Add To WishList Test Scenario");

            ITDepot_HomePage homePage = new(driver);
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/ITDepotInputData.xlsx";

            string? sheetName = "ITDepotInput";
            List<ITDepotData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {
                if (!driver.Url.Equals("https://www.theitdepot.com/"))
                {
                    driver.Navigate().GoToUrl("https://www.theitdepot.com/");
                }
                homePage.InputSearchBox(excelData.SearchItem);
                var viewproductPage = homePage.ViewProduct();
                Thread.Sleep(3000);
               var buyNowPage = viewproductPage.ClickBuyNow(excelData.ProductNo);
               var wishlistPage = buyNowPage.WishListClick();
                Thread.Sleep(3000);
                wishlistPage.WishListCloseClick();
                Thread.Sleep(3000);
               
                try
                {
                    IWebElement? emptyelement = driver.FindElement(By.XPath("//p[text()='Your Wishlist is Empty']"));
                    Assert.That(emptyelement.Text.Equals("Your Wishlist is Empty"));
                    Log.Information("Search And Add To WishList Test -Pass");
                    
                    test.Info("Search And Add To WishList Test -Pass");

                    test.Pass("Search And Add To WishList Test Pass");
                    string filepath = ScreenShots.TakeScreenShot(driver);


                    test.AddScreenCaptureFromPath(filepath);
                    //var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    // test.AddScreenCaptureFromBase64String(ss);


                }
                catch(AssertionException)
                {
                    ScreenShots.TakeScreenShot(driver);
                    Log.Error("Search And Add To WishList Test -Fail");
                    test = extent.CreateTest("Search And Add To WishList Test Scenario");
                    test.Fail("Search And Add To WishList Test Fail");
                    //var ss = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                    //test.AddScreenCaptureFromBase64String(ss);
                    string filepath = ScreenShots.TakeScreenShot(driver);


                    test.AddScreenCaptureFromPath(filepath);

                }
            }
        }
    }
}
