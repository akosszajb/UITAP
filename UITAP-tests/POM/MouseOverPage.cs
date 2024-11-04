using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class MouseOverPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private Actions _actions;

    private IWebElement title => _driver.FindElement(By.XPath("//h3[contains(text(), 'Mouse Over')]"));
    private IWebElement ClickMeLink =>
        _driver.FindElement(By.XPath("//*[@title = 'Click me' and (text() = 'Click me' or . = 'Click me')]"));
    private IWebElement ClickMeLinkPlacedMouse => _driver.FindElement(By.XPath("//*[@title = 'Active Link' and (text() = 'Click me' or . = 'Click me')]"));
    private IWebElement LinkButtonLink => _driver.FindElement(By.XPath("//*[@title = 'Link Button' and (text() = 'Link Button' or . = 'Link Button')]"));
    private IWebElement LinkButtonLinkPlacedMouse => _driver.FindElement(By.XPath("//*[@title = 'Link Button' and (text() = 'Link Button' or . = 'Link Button')]"));
    private IWebElement ClickMeCounter => _driver.FindElement(By.Id("clickCount"));
    private IWebElement LinkButtonCounter => _driver.FindElement(By.Id("clickButtonCount"));
    
    
    public MouseOverPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
        _actions = new Actions(_driver);
    }

    public void ClickMeLinkClicker()
    {
        _actions.MoveToElement(ClickMeLink).Perform();
        ClickMeLinkPlacedMouse.Click();
        _actions.MoveToElement(title).Perform();
    }
    
    public void LinkButtonLinkClicker()
    {
        _actions.MoveToElement(LinkButtonLink).Perform();
        LinkButtonLinkPlacedMouse.Click();
        _actions.MoveToElement(title).Perform();
    }

    public int GetClickMeCounter()
    {
        return Convert.ToInt32(ClickMeCounter.Text);
    }
    
    public int GetLinkButtonCounter()
    {
        return Convert.ToInt32(LinkButtonCounter.Text);
    }
}