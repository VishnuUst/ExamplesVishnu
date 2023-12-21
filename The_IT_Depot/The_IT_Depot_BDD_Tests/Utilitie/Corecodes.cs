﻿
using The_IT_Depot_BDD_Tests.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_IT_Depot_BDD_Tests
{
    public class Corecodes
    {
        

        public void TakeScreenShot(IWebDriver driver)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshorts/scs_TheItDepot" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            screenshot1.SaveAsFile(filepath);

        }

        protected void LogTestResult(string testName, string result, string erroMessage = null)
        {
            Log.Information(result);
            if (erroMessage == null)
            {
                Log.Information(testName + "Passed");
            }
            else
            {
                Log.Error($"Test Failed for {testName}." + $"\n Exception: \n {erroMessage}");
            }

        }



    }
}
