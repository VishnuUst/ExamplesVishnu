﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using TechTalk.SpecFlow;

namespace The_IT_Depot_BDD_Tests.Hooks
{
    [Binding]
   
    public sealed class BeforeHooks
    {
        public static IWebDriver? driver;

        [BeforeFeature(Order = 1)]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }

        [BeforeFeature(Order = 2)]
        public static void LogFileCreation()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilePath = currDir + "/Logs/log_TheItDepot" + DateTime.Now.ToString("yyyy.mm.dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}