using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class OverlappedElementPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement IdInputbar => _driver.FindElement(By.Id("id"));
    private IWebElement NameInputbar => _driver.FindElement(By.Id("name"));
    
    public OverlappedElementPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void IdFormFiller(string id)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        
        js.ExecuteScript("arguments[0].scrollIntoView(true);", IdInputbar);
        IdInputbar.Clear();
        IdInputbar.SendKeys(id);
    }
    
    public void NameFormFiller(string name)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        
        js.ExecuteScript("arguments[0].scrollIntoView(true);", NameInputbar);
        NameInputbar.Clear();
        NameInputbar.SendKeys(name);
    }

    public string GetIdFormText()
    {
        return IdInputbar.GetAttribute("value");
    }
    
    public string GetNameFormText()
    {
        return NameInputbar.GetAttribute("value");
    }
}