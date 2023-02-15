using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Internal;
using OpenQA.Selenium.DevTools.V107.Animation;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools;

namespace test;

[TestFixture]
public abstract class TestBase
{
    protected IWebDriver WebDriver
    {
        get => WebDriverFactory.Driver;
    }


    //consts
    private const string ERP_URL = "http://197.13.18.37:5000/";
    private const string LOGIN_INPUT = "email1";
    private const string PASSWORD_INPUT = "//*[@id=\"password1\"]/div/input";
    private const string LOGIN = "Administrateur";
    private const string PASSWORD = "1234@Test";
    private const string LOGIN_BUTTON = "/html/body/app-root/app-account/app-login/div/div/div/div/div[2]/button";
    private const string HOME_PAGE_URL = "http://197.13.18.37:5000/app/home";



    [TearDown]
    public void TearDown()
    {
        var testResult = GetCurrentTestResult();
        var testName = GetCurrentTestName();
        WebDriverFactory.CloseDriver();
    }
    public ResultState GetCurrentTestResult()
    {
        TestExecutionContext context = TestExecutionContext.CurrentContext;
        var result = context.CurrentResult;
        return result.ResultState;
    }
    public string GetCurrentTestName()
    {
        TestExecutionContext context = TestExecutionContext.CurrentContext;
        var result = context.CurrentTest.Name;
        return result;
    }

    public IWebElement WaitForElementIsVisible(By value, string elementName = null)
    {
        // Initialisation des variables
        int compteur = 1;
        bool isFound = false;
        IWebElement element = null;

        WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3));
        while (compteur <= 10 && !isFound)
        {
            try
            {
                var elm = wait.Until(ExpectedConditions.ElementIsVisible(value));
                isFound = true;
                element = elm;
            }
            catch
            {
                compteur++;
            }
        }

        if (!isFound)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToShortDateString()} {DateTime.UtcNow.ToLongTimeString()}] [WaitForElementIsVisible] Element not visible {value}");

            if (elementName != null)
            {
                throw new Exception($"L'element {elementName} n'est pas visible dans la page.");
            }
            else
            {
                throw new Exception($"L'element {value} n'est pas visible dans la page.");
            }
        }

        return element;
    }

    public void LoginAsAdmin()
    {
        WebDriver.Navigate().GoToUrl(ERP_URL);
        var loginInput = WaitForElementIsVisible(By.Id(LOGIN_INPUT));
        loginInput.SendKeys(LOGIN);
        var mdpInput = WaitForElementIsVisible(By.XPath(PASSWORD_INPUT));
        mdpInput.SendKeys(PASSWORD);
        var loginBtn = WaitForElementIsVisible(By.XPath(LOGIN_BUTTON));
        Thread.Sleep(1000);
        loginBtn.Click();
        Thread.Sleep(1000);
    }
}