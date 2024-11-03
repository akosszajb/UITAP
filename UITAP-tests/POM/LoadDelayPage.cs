using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class LoadDelayPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement Button => _driver.FindElement(By.ClassName("btn-primary"));
  
    public LoadDelayPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void ButtonClicker()
    {
        Button.Click();
    }
    
    public bool TryFindElement(By locator, int timeoutInMilliseconds)
    {
        DateTime endTime = DateTime.Now.AddMilliseconds(timeoutInMilliseconds);
    
        while (DateTime.Now < endTime)
        {
            try
            {
                if (_driver.FindElement(locator).Displayed)
                    return true;
            }
            catch (NoSuchElementException)
            {
               
            }
            Thread.Sleep(10);
        }
        return false;
    }
}