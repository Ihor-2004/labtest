using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace YourProjectNamespace
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginSteps()
        {
            // Ініціалізуємо драйвер у конструкторі
            driver = new ChromeDriver(); 
            loginPage = new LoginPage(driver);
        }

        [Given(@"I am on the banking website")]
        public void GivenIAmOnTheBankingWebsite()
        {
            loginPage.OpenLoginPage("https://www.globalsqa.com/angularJs-protractor/BankingProject"); 
        }

        [When(@"I select ""Bank Manager Login"" option")]
        public void WhenISelectLoginAsManagerOption()
        {
            loginPage.ClickLoginAsBankManager();
        }


        [Then(@"I click Add Customer")]
        public void ClickAddCustomer()
        {
            loginPage.ClickAddCustomer();
        }

        [Then(@"I enter firstname")]
        public void EnterFirstName()
        {
            loginPage.EnterFirstName("Silvester");
        }

        [Then(@"I enter lastname")]
        public void EnterLastName()
        {
            loginPage.EnterLastName("Stalone");
        }

        [Then(@"I enter post code")]
        public void EnterPostCode()
        {
            loginPage.EntePostCode("10001");
        }

        [When(@"I click Add Customer")]

        public void WhenIClickAddCustomer()
        {
            loginPage.ClickAddCustomerButton();
        }

        [Then(@"I should see a success message")]
        public void ThenIShouldSeeASucseedMessage()
        {
            loginPage.IsSucseedTextVisible();
        }

        [When(@"I enter the withdrawal amount as full sum x 2")]

        [Then(@"I should close Chrome")]
        public void CloseChrome()
        {
            loginPage.CloseDriver();
        }
    }
}
