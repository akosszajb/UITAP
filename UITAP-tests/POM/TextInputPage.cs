using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Script;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class TextInputPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement Button => _driver.FindElement(By.ClassName("btn-primary"));
    private IWebElement Inputbar => _driver.FindElement(By.Id("newButtonName"));
  
    public TextInputPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void InputbarFiller(string text)
    {
        Inputbar.Clear();
        Inputbar.SendKeys(text);
    }
    
    public void InputbarFillerWithNumbers(int number)
    {
        Inputbar.Clear();
        string stringNumber = number.ToString();
        Inputbar.SendKeys(stringNumber);
    }
    
    public void ButtonClicker()
    {
        Button.Click();
    }
}