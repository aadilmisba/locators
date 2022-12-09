using HT_Design_Pattern.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HT_Design_Pattern.PageObjects;
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
using Assert = NUnit.Framework.Assert;

namespace HT_Design_Pattern
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string username = "aadilmuhammadu@gmail.com";
            string password = "Test@123";
            string senderMail = "aadilmisba3@gmail.com";
            string subject = "Testing Subject";
            string textbox = " Testing Send Email";
            var loginPage = new LoginPage();
            loginPage.Open();

            loginPage.Login(username, password);
            Assert.AreEqual(loginPage.PasswordField.GetAttribute("value"), password);
            Assert.AreEqual(loginPage.UsernameField.GetAttribute("value"), username);

            //Assert for login is successful
            Assert.True(loginPage.MainPage.Displayed, "The login is successful");

            var InboxPage = new InboxPage();
            InboxPage.Compose(senderMail, subject, textbox);

            var DraftPage = new DraftPage();
            DraftPage.DraftMails();
            // Verify the draft content(addressee, subject and body – should be the same as in 3).
            Assert.AreEqual(DraftPage.checkSubject.GetAttribute("value"), "Testing Subject");
            Assert.AreEqual(DraftPage.checkTextbox.Text, " Testing Send Email");
            // Verifying mail is present in Draft folder.
            Assert.IsTrue(DraftPage.DraftMail.Displayed);

            var SentPage = new SentPage();
            SentPage.SendMails();
            SentPage.LogOut();

        }


    }
}