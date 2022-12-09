﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void gmailTest()
        {

            WebElement usernameEnter = (WebElement)driver.FindElement(By.Id("identifierId"));
            usernameEnter.SendKeys("aadilmuhammadu@gmail.com");
           NUnit.Framework.Assert.AreEqual(usernameEnter.GetAttribute("value"), "aadilmuhammadu@gmail.com");

            //driver.FindElement(By.XPath("//span[contains(text(),'Next')]")).Click();
            driver.FindElement(By.Id("identifierNext")).Click();

            WebElement passwordEnter = (WebElement)driver.FindElement(By.XPath("//*[@id='password']//input"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(passwordEnter));
            passwordEnter.SendKeys("Test@123");
            NUnit.Framework.Assert.AreEqual(passwordEnter.GetAttribute("value"), "Test@123");

            //driver.FindElement(By.XPath("//span[contains(text(),'Next')]")).Click();
            driver.FindElement(By.Id("passwordNext")).Click();

            //NUnit.Framework.Assert for login is successful
            NUnit.Framework.Assert.True(driver.FindElement(By.CssSelector("body")).Displayed, "The login is successful");

            WebElement composeButton = (WebElement)driver.FindElement(By.XPath("//div[@jscontroller='eIu7Db']"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(composeButton));
            composeButton.Click();

            //Task.Delay(2000).Wait();

            //WebElement senderMail = (WebElement)driver.FindElement(By.XPath("//input[@role='combobox']"));
            WebElement senderMail = (WebElement)driver.FindElement(By.CssSelector("input[role=combobox]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(senderMail));
            senderMail.SendKeys("aadilmisba3@gmail.com");

            //WebElement sentSubject = (WebElement)driver.FindElement(By.XPath("//input[@aria-label='Subject']"));
            WebElement sentSubject = (WebElement)driver.FindElement(By.Name("subjectbox"));
            sentSubject.SendKeys("Sample Subject");

            WebElement sentTextbox = (WebElement)driver.FindElement(By.XPath("//div[@aria-label='Message Body']"));
            sentTextbox.SendKeys("Test Mail");
            driver.FindElement(By.XPath("//img[@alt='Close']")).Click();

            WebElement draftsField = (WebElement)driver.FindElement(By.XPath("//a[contains(text(),'Drafts')]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(draftsField));
            draftsField.Click();

            WebElement searchMail = (WebElement)driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchMail));
            searchMail.Click();
            NUnit.Framework.Assert.AreEqual(true, searchMail.Displayed); // Verify, that the mail presents in ‘Drafts’ folder.

            //Task.Delay(1000).Wait();   

            // Verify the draft content(addressee, subject and body – should be the same as in 3).
            WebElement checkSenderMail = (WebElement)driver.FindElement(By.XPath("//div[@class='aoD hl']"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(checkSenderMail));
            //WebElement checkSubject = (WebElement)driver.FindElement(By.XPath("//input[@name ='subjectbox']"));
            WebElement checkSubject = (WebElement)driver.FindElement(By.CssSelector("input[name=subjectbox]"));
            WebElement checkTextbox = (WebElement)driver.FindElement(By.XPath("//div[@role='textbox']"));

            NUnit.Framework.Assert.AreEqual(checkSenderMail.Text, "aadilmisba3@gmail.com");
            NUnit.Framework.Assert.AreEqual(checkSubject.GetAttribute("value"), "Sample Subject");
            NUnit.Framework.Assert.AreEqual(checkTextbox.Text, "Test Mail");

            driver.FindElement(By.XPath("//div[text()='Send']")).Click();
            WebElement sendField = (WebElement)driver.FindElement(By.XPath("//a[contains(text(),'Sent')]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(sendField));
            sendField.Click();

            WebElement searchSentMail = (WebElement)driver.FindElement(By.XPath("//div[@role='link']//span[contains(text(),'Sample Subject')]"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchSentMail));
            searchSentMail.Click();
            //NUnit.Framework.Assert.AreEqual(true, searchSentMail.Displayed);

            WebElement InboxField = (WebElement)driver.FindElement(By.XPath("//a[contains(text(),'Inbox')]"));
            InboxField.Click();

            WebElement AccountField = (WebElement)driver.FindElement(By.CssSelector("img.gb_Ca.gbii"));
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
