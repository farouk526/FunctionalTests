using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObjects;
 public class PageBase
{

    protected readonly IWebDriver _webDriver;
    protected PageBase(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    private const string HOME_PAGE_URL = "http://197.13.18.37:5000/app/home";

    public HomePage GoToHomePage()
    {
        _webDriver.Navigate().GoToUrl(HOME_PAGE_URL);
        return new HomePage(_webDriver);
    }
}

