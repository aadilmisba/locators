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
    public class LoginPage : BasePage
    {
        public LoginPage() : base("")
        {
        }

        public IWebElement UsernameField => WebDriver.GetInstance().FindElement(By.Id("identifierId"));

        public IWebElement NextButton => WebDriver.GetInstance().FindElement(By.Id("identifierNext"));
        public IWebElement PasswordField => WebDriver.GetInstance().FindElement(By.XPath("//*[@id='password']//input"));

        public WebDriverWait wait = new WebDriverWait(WebDriver.GetInstance(), TimeSpan.FromSeconds(50));
        
        public IWebElement LoginButton => WebDriver.GetInstance().FindElement(By.Id("passwordNext"));

        public IWebElement MainPage => WebDriver.GetInstance().FindElement(By.CssSelector("body"));

        //TODO string senderMail, string subject, string textbox parameter values are not used in function
        public void Login(string username, string password)
        {
            //passing the value from test
            UsernameField.SendKeys(username); 
            
            var UsernameButton = new Button(NextButton);
            UsernameButton.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));
            //pass this value from test
            PasswordField.SendKeys(password); 
            var PasswordButton = new Button(LoginButton);
            PasswordButton.Click();

        }
    }
}