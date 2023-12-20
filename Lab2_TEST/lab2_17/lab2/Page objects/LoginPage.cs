using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq.Expressions;
using System.Threading;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    // Метод для відкриття сторінки в браузері
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для вибору опції "Bank Manager Login"
    public void ClickLoginAsBankManager()
    {
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Bank Manager Login']")));
        loginButton.Click();
    }
    public void ClickAddCustomer()
    {
        Thread.Sleep(1000);
        IList<IWebElement> buttons = driver.FindElements(By.CssSelector(".btn.btn-lg.tab"));
        wait.Until(ExpectedConditions.ElementToBeClickable(buttons[0]));
        buttons[0].Click();
    }

    public void EnterFirstName(string firstName)
    {
        Thread.Sleep(2000);
        IList<IWebElement> fields = driver.FindElements(By.XPath("//input"));
        fields[0].Clear();
        fields[0].SendKeys(firstName);
    }

    public void EnterLastName(string lastName)
    {
        IList<IWebElement> fields = driver.FindElements(By.XPath("//input"));
        fields[1].Clear();
        fields[1].SendKeys(lastName);
    }

    public void EntePostCode(string postCode)
    {
        IList<IWebElement> fields = driver.FindElements(By.XPath("//input"));
        fields[2].Clear();
        fields[2].SendKeys(postCode);
    }

    public void ClickAddCustomerButton()
    {
        IWebElement processButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Add Customer']")));
        processButton.Click();
    }

    public bool IsSucseedTextVisible()
    {
        IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());

        string alertText = alert.Text;
        Thread.Sleep(3000);
        if (alertText.Contains("Customer added successfully"))
        {
            alert.Accept();
            return true;
        }
        else
        {
            alert.Dismiss();
            return false;
        }
    }

        public void CloseDriver()
    {
        driver.Quit();
    }

}
