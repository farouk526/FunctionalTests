using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
namespace test;

public class WebDriverFactory
{
    private static IWebDriver _webDriver;

    public static IWebDriver Driver
    {
        get
        {
            if (_webDriver == null)
                InitializeDriver(Browser.Chrome);
            return _webDriver;
        }
    }
    public enum Browser
    {
        Firefox,
        Chrome,
        IE
    }
    public static void InitializeDriver(Browser browser)
    {
        
        switch (browser)
        {
            case Browser.Chrome:
                var options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");
                options.AddArgument("--lang=en-US");
                _webDriver = new ChromeDriver(options);
                break;
            case Browser.Firefox:
                _webDriver = new FirefoxDriver();
                break;
            case Browser.IE:
                _webDriver = new InternetExplorerDriver();
                break;
            default:
                _webDriver = new ChromeDriver();
                break;
        }
        _webDriver.Manage().Window.Maximize();
        
    }

    public static void CloseDriver()
    {
        if (_webDriver != null)
        {
            _webDriver.Close();
            _webDriver.Quit();
            _webDriver.Dispose();
            _webDriver = null;
        }
    }
}
