using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq.Expressions;
using System.Threading;

namespace Lab_2_specflow.PageObjects
{
    internal class AmountPageObject
    {
        private IWebDriver webDriver;

        public AmountPageObject(IWebDriver web) { webDriver = web; }
        private readonly string AmountInputXPath="/html/body/div/div/div[2]/div/div[4]/div/form/div/input";
        private IWebElement AmountInputObject => webDriver.FindElement(By.XPath(AmountInputXPath));

        public void SendAmount(string amount) { AmountInputObject.SendKeys(amount);Thread.Sleep(1000); }


        private readonly string SubmitButtonXPath = "/html/body/div/div/div[2]/div/div[4]/div/form/button";
        private IWebElement SubmitButton => webDriver.FindElement(By.XPath(SubmitButtonXPath));
        public void SubmitButtonClick() { SubmitButton.Click(); Thread.Sleep(1000); }


        private readonly string MessageXPath = "/html/body/div/div/div[2]/div/div[4]/div/span";
        private IWebElement MessageObject => webDriver.FindElement(By.XPath(AmountInputXPath));

        public bool MessageIsVisible()
        {
            try
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(3));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(MessageXPath)));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }



    }
}
