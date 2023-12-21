using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_Tests.Utilities
{
    internal class ScreenShots
    {
        /*ScreenShot Taking*/
        public static string TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/ScreenShorts/ITDepot" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            screenshot1.SaveAsFile(filepath);
            return filepath;

        }
    }
}
