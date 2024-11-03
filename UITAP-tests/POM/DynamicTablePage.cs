using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class DynamicTablePage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement WAIARIALink => _driver.FindElement(By.CssSelector("a[href='https://www.w3.org/TR/wai-aria-practices/examples/table/table.html']"));
    
    public DynamicTablePage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void OpenWaiariaLink()
    {
        WAIARIALink.Click();
    }
}