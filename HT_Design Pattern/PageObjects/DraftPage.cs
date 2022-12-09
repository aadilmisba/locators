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
    public class DraftPage : BasePage
    {
        public DraftPage() : base("")
        {
        }

        public IWebElement DraftField => WebDriver.GetInstance().FindElement(By.XPath("//a[contains(text(),'Drafts')]"));

        public IWebElement DraftMail => WebDriver.GetInstance().FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Testing Subject')]"));

        public WebDriverWait wait = new WebDriverWait(WebDriver.GetInstance(), TimeSpan.FromSeconds(10));

        public IWebElement SendMail => WebDriver.GetInstance().FindElement(By.XPath("//div[text()='Send']"));
        public IWebElement checkSubject = (WebElement)WebDriver.GetInstance().FindElement(By.CssSelector("input[name=subjectbox]"));
        public IWebElement checkTextbox = (WebElement)WebDriver.GetInstance().FindElement(By.XPath("//div[@role='textbox']"));

        public void DraftMails()
        {

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftField));
            var Draftbutton = new Button(DraftField);
            Draftbutton.Click();
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(DraftMail));
            var DraftMailbutton = new Button(DraftMail);
            DraftMailbutton.Click();
           
            //SendMail.Click();
            var SendMailbutton = new Button(SendMail);
            SendMailbutton.Click();
        }

        

    }

}
