using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_Design_Pattern
{
    public class Button
    {
        private IWebElement element;

        public Button(IWebElement el)
        {
            element = el;
        }

        public T Click<T>() where T : class
        {
            element.Click();
            return Activator.CreateInstance<T>();
        }

        public void Click()
        {
            element.Click();
        }

        public string GetText()
        {
            return element.Text;
        }
    }
}
