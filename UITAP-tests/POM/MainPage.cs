using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class MainPage
{
    private readonly IWebDriver _driver;
    
    private readonly WebDriverWait _wait;

    private IWebElement DynamicId => _driver.FindElement(By.LinkText("Dynamic ID"));
    
    public MainPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }
    
    public void LoadMainPage()
    {
        _driver.Navigate().GoToUrl("http://localhost:3000/");
    }

    public void OpenDynamicIDPage()
    {
        DynamicId.Click();
    }
}