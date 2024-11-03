using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ScrollbarsPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement Button => _driver.FindElement(By.ClassName("btn-primary"));
    
    private IWebElement ScrollArea => _driver.FindElement(By.CssSelector("div[style*='overflow-y: scroll']"));
    
    public ScrollbarsPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void ButtonClick()
    {
        Button.Click();
    }

    public void ButtonClickerWithScrolling()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        
        js.ExecuteScript("arguments[0].scrollIntoView(true);", Button);

        ButtonClick();
    }
    
}