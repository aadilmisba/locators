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


namespace HT_Design_Pattern.PageObjects
{

    public class SentPage : BasePage
    {
        public SentPage() : base("")
        {
        }

        public IWebElement SentField => WebDriver.GetInstance().FindElement(By.XPath("//a[contains(text(),'Sent')]"));

        public IWebElement SentMail => WebDriver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Testing Subject')]"));

        public WebDriverWait wait = new WebDriverWait(WebDriver.GetInstance(), TimeSpan.FromSeconds(50));


        public IWebElement AccountField => WebDriver.GetInstance().FindElement(By.XPath("//img[@class='gb_Ia gbii']"));

        public IWebElement SignOut => WebDriver.GetInstance().FindElement(By.XPath("//div[text()='Sign out']"));


        public void SendMails()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentField));
            var SentButton = new Button(SentField);
            SentButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SentMail));
            var SentMailButton = new Button(SentMail);
            SentMailButton.Click();
        }


        public void LogOut()
        {
            var AccountButton = new Button(AccountField);
            AccountButton.Click();
            WebDriver.GetInstance().SwitchTo().Frame("account");
            var SignOutButton = new Button(SignOut);
            SignOutButton.Click();
            WebDriver.GetInstance().SwitchTo().ParentFrame().Dispose();

        }
    }

}
