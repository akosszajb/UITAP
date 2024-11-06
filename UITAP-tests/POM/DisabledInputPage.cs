using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class DisabledInputPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement EnableEditButton => _driver.FindElement(By.ClassName("btn-primary"));
    private IWebElement ChangeMeInputBar => _driver.FindElement(By.Id("inputField"));
    private IWebElement OpStatusInfo => _driver.FindElement(By.Id("opstatus"));
   
    public DisabledInputPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void EnableEditButtonClicker()
    {
        EnableEditButton.Click();
    }

    public void FillChangeMeInputBar(string text)
    {
        ChangeMeInputBar.SendKeys(text);
    }

    public string GetOpStatusText()
    {
        return OpStatusInfo.Text;
    }

    public string GetChangeMeInputBarValue()
    {
        return ChangeMeInputBar.GetAttribute("value");
    }
}