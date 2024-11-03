using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ProgressBarPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement StartButton => _driver.FindElement(By.ClassName("btn-primary"));
    
    private IWebElement StopButton => _driver.FindElement(By.ClassName("btn-test"));
    
    public ProgressBarPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void StartProgressBar()
    {
        StartButton.Click();
    }

    public void StopProgressBar()
    {
        StopButton.Click();
    }
}