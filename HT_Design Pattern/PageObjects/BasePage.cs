using System;
using Nest;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace HT_Design_Pattern.PageObjects
{
    public abstract class BasePage
    {
        private readonly string url;

        protected BasePage(string url)
        {
            this.url = url;
        }

        public void Open()
        {
            WebDriver.GetInstance().Navigate().GoToUrl("https://mail.google.com/" + url);
        }
    }
}
