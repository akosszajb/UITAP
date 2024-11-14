using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ShadowDOMPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private IWebElement GeneratedGuidField => _driver.FindElement(By.XPath("//*/text()[normalize-space(.)='']/parent::*"));
    public ShadowDOMPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void GenerateGuid()
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
        IWebElement buttonGenerate = (IWebElement)jsExecutor.ExecuteScript(
            "return document.querySelector('guid-generator').shadowRoot.querySelector('#buttonGenerate')");
        IWebElement buttonCopy = (IWebElement)jsExecutor.ExecuteScript(
            "return document.querySelector('guid-generator').shadowRoot.querySelector('#buttonCopy')");
        buttonGenerate.Click();
    }

    public void CopyGeneratedGuid()
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
        IWebElement buttonCopy = (IWebElement)jsExecutor.ExecuteScript(
            "return document.querySelector('guid-generator').shadowRoot.querySelector('#buttonCopy')");
        buttonCopy.Click();
    }

    public string GetGeneratedGuidText()
    {
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
        IWebElement generatedGuidField = (IWebElement)jsExecutor.ExecuteScript(
            "return document.querySelector('guid-generator').shadowRoot.querySelector('#editField')");
        return generatedGuidField.GetAttribute("value");
    }

}