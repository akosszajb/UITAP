using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ClassAttributePage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement GreenButton => _driver.FindElement(By.XPath("//button[contains(concat(' ', normalize-space(@class), ' '), ' btn-success ')]"));
    private IWebElement BlueButton => _driver.FindElement(By.XPath("//button[contains(concat(' ', normalize-space(@class), ' '), ' btn-primary ')]"));
    private IWebElement YellowButton => _driver.FindElement(By.XPath("//button[contains(concat(' ', normalize-space(@class), ' '), ' btn-warning ')]"));
    private IAlert Alert => _driver.SwitchTo().Alert();
            
    public ClassAttributePage(IWebDriver driver, WebDriverWait wait)
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
    
    public void YellowButtonClicker()
    {
        YellowButton.Click();   
    }
    
    public void AlertmessageOKClicker()
    {
        Alert.Accept();
    }
}