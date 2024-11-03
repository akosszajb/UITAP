using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class VerifyTextPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    public VerifyTextPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    
}