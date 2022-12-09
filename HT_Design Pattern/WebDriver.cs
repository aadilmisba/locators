using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HT_Design_Pattern
{
    public class WebDriver
    {
        private static IWebDriver? webDriver;

        public static IWebDriver GetInstance()
        {
            if (webDriver == null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                webDriver = new ChromeDriver(chromeOptions);
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            return webDriver;
        }

        public static void Close()
        {
            webDriver?.Quit();
            webDriver = null;
        }
    }
}
