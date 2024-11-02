using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class HiddenLayersPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement GreenButton => _driver.FindElement(By.ClassName("btn-success"));
    private IWebElement BlueButton => _driver.FindElement(By.ClassName("btn-primary"));
     
    public HiddenLayersPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void GreenButtonClicker()
    {
        GreenButton.Click();
    }
    
    public void BlueButtonClicker()
    {
        BlueButton.Click();
    }
}