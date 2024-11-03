using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ClientSideDelayPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement Button => _driver.FindElement(By.ClassName("btn-primary"));
  
    public ClientSideDelayPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void ButtonClicker()
    {
        Button.Click();
    }
}