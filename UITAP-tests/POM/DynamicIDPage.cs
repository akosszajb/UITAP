using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class DynamicIDPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement DynamicIdButton => _driver.FindElement(By.ClassName("btn-primary"));
     
    public DynamicIDPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void ButtonClicker()
    {
        DynamicIdButton.Click();   
    }
}