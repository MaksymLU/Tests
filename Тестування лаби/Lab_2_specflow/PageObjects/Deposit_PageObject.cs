using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_specflow.PageObjects
{
    internal class DepositPageObject
    {
        private IWebDriver webDriver;

        public DepositPageObject(IWebDriver web) { webDriver = web; }
        private readonly string DepositeButtonXPath = "/html/body/div/div/div[2]/div/div[3]/button[2]";
        private IWebElement DepositeButton => webDriver.FindElement(By.XPath(DepositeButtonXPath));
        public void DepositeButtonClick() 
        {
            Thread.Sleep(1000);
            DepositeButton.Click();
            Thread.Sleep(1000); 
        }
    }
}
