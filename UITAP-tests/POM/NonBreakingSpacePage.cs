using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class NonBreakingSpacePage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement Button => _driver.FindElement(By.XPath("//button[@type = 'button' and (text() = 'My\u00a0Button')]"));
    public NonBreakingSpacePage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void ButtonClick()
    {
        Button.Click();
    }
}