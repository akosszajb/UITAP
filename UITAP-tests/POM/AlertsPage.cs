using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AlertsPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement AlertButton => _driver.FindElement(By.Id("alertButton"));
    private IWebElement ConfirmButton => _driver.FindElement(By.Id("confirmButton"));
    private IWebElement PromptButton => _driver.FindElement(By.Id("promptButton"));
    
    private IAlert Alert => _wait.Until(driver=> driver.SwitchTo().Alert());
  
    public AlertsPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void AlertButtonClicker()
    {
        AlertButton.Click();
    }
    
    public void ConfirmButtonClicker()
    {
        ConfirmButton.Click();
    }
    
    public void PromptButtonClicker()
    {
        PromptButton.Click();
    }
    
    public void AlertMessageOKClicker()
    {
        Alert.Accept();
    }
    
    public void AlertMessageCancelClicker()
    {
        Alert.Dismiss();
    }

    public void PromptFiller(string input)
    {
        Alert.SendKeys(input);
    }

    public string GetAlertMsgText()
    {
        return Alert.Text;
    }

}