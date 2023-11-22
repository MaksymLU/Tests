using Lab_2_specflow.PageObjects;
using Lab_2_specflow.Features;
using Lab_2_specflow.StepDefinitions;
using Lab2.Drivers;
using NUnit.Framework;

namespace Lab_2_specflow.StepDefinitions
{


    [Binding]
    public sealed class DepositStepDefinitions
    {
        private readonly CustomerLoginPageObject customerLoginPageObject;
        private readonly DepositPageObject depositPageObject;
        private readonly AmountPageObject amountPageObject;
        private readonly ScenarioContext _scenarioContext;
        private CustomerDeposit Customer;

        public DepositStepDefinitions(BrowserDriver browserDriver, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            customerLoginPageObject = new CustomerLoginPageObject(browserDriver.Current);
            depositPageObject = new DepositPageObject(browserDriver.Current);
            amountPageObject = new AmountPageObject(browserDriver.Current);
            Customer = new CustomerDeposit();

        }

        [Given(@"Customer with details:(.*),(.*)")]
        public void GivenCustomerWithDetailsNameAmount(string Name, string Amount)
        {
            Customer = new CustomerDeposit(Name, Amount);
        }

        [When(@"I log in as a ""([^""]*)""")]
        public void WhenILogInAsA(string customer)
        {
            customerLoginPageObject.LoginCustomerButton();
            customerLoginPageObject.SelectCustomer(Customer.Name);
            customerLoginPageObject.PressLoginButton();
        }

        [When(@"I navigate to ""([^""]*)"" page")]
        public void WhenINavigateToPage(string deposit)
        {
            depositPageObject.DepositeButtonClick();
        }

        [When(@"fill the data")]
        public void WhenFillTheData()
        {
            amountPageObject.SendAmount(Customer.Amount);

        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            amountPageObject.SubmitButtonClick();
        }

        [Then(@"Message should be Deposit Successful")]
        public void ThenMessageShouldBeDepositSuccessful()
        {
            Assert.IsTrue(amountPageObject.MessageIsVisible());
        }

        [Then(@"Message shouldn't be displayed")]
        public void ThenNoMessageShouldBeDisplayed()
        {
            Assert.IsFalse(amountPageObject.MessageIsVisible());
        }

    }
}





