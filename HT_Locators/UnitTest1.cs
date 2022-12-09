using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Nest;
using NUnit.Framework;
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

namespace HT_Locators
{
    [TestClass]
    public class UnitTest1
    {
        public readonly IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            //open the browser  
            //navigate to URL  
            driver.Navigate().GoToUrl("https://mail.google.com/");
            //Maximize the browser window  
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void GmailTest()
        {

            var usernameEnter = driver.FindElement(By.Id("identifierId"));
            usernameEnter.SendKeys("aadilmuhammadu@gmail.com");
            Assert.AreEqual(usernameEnter.GetAttribute("value"), "aadilmuhammadu@gmail.com");

            //driver.FindElement(By.XPath("//span[contains(text(),'Next')]")).Click();
            driver.FindElement(By.Id("identifierNext")).Click();

            var passwordEnter = driver.FindElement(By.XPath("//*[@id='password']//input"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));

            wait.Until(ExpectedConditions.ElementToBeClickable(passwordEnter));
            passwordEnter.SendKeys("Test@123");
            Assert.AreEqual(passwordEnter.GetAttribute("value"), "Test@123");

            //driver.FindElement(By.XPath("//span[contains(text(),'Next')]")).Click();
            driver.FindElement(By.Id("passwordNext")).Click();

            //NUnit.Framework.Assert for login is successful
            Assert.True(driver.FindElement(By.CssSelector("body")).Displayed, "The login is successful");

            WebElement composeButton = (WebElement)driver.FindElement(By.XPath("//div[@jscontroller='eIu7Db']"));
            wait.Until(ExpectedConditions.ElementToBeClickable(composeButton));
            composeButton.Click();


            //WebElement senderMail = (WebElement)driver.FindElement(By.XPath("//input[@role='combobox']"));
            var senderMail = driver.FindElement(By.CssSelector("input[role=combobox]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(senderMail));
            senderMail.SendKeys("aadilmisba3@gmail.com");

            //WebElement sentSubject = (WebElement)driver.FindElement(By.XPath("//input[@aria-label='Subject']"));
            var  sentSubject = driver.FindElement(By.Name("subjectbox"));
            sentSubject.SendKeys("Sample Subject");

            var sentTextbox = driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));
            sentTextbox.SendKeys("Test Mail");
            driver.FindElement(By.XPath("//img[@alt='Close']")).Click();

            var draftsField = driver.FindElement(By.XPath("//a[contains(text(),'Drafts')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(draftsField));
            draftsField.Click();

            var searchMail = driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchMail));
            searchMail.Click();
            Assert.AreEqual(true, searchMail.Displayed); // Verify, that the mail presents in ‘Drafts’ folder.


            // Verify the draft content(addressee, subject and body – should be the same as in 3).
            var checkSenderMail = driver.FindElement(By.XPath("//div[@class='aoD hl']"));
            wait.Until(ExpectedConditions.ElementToBeClickable(checkSenderMail));
            //WebElement checkSubject = (WebElement)driver.FindElement(By.XPath("//input[@name ='subjectbox']"));
            var checkSubject = driver.FindElement(By.CssSelector("input[name=subjectbox]"));
            var checkTextbox = driver.FindElement(By.XPath("//div[@role='textbox']"));

            Assert.AreEqual(checkSenderMail.Text, "aadilmisba3@gmail.com");
            Assert.AreEqual(checkSubject.GetAttribute("value"), "Sample Subject");
            Assert.AreEqual(checkTextbox.Text, "Test Mail");

            driver.FindElement(By.XPath("//div[text()='Send']")).Click();
            var sendField = driver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(sendField));
            sendField.Click();

            var searchSentMail = driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchSentMail));
            searchSentMail.Click();
            Assert.IsTrue(searchSentMail.Displayed);

            var InboxField = driver.FindElement(By.XPath("//a[contains(text(),'Inbox')]"));
            InboxField.Click();

            var AccountField = driver.FindElement(By.CssSelector("img.gb_Ca.gbii"));
            AccountField.Click();
            driver.SwitchTo().Frame("account");
            driver.FindElement(By.XPath("//div[text()='Sign out']")).Click();
            driver.SwitchTo().ParentFrame();

        }


        [TearDown]
        public void EndTest()
        {
            //close the browser  
            //TODO it's better to use Quit() for proper cleanup and disposal of WebDriver instance
            driver.Quit();
        }
    }
}
